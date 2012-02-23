using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Ionic.Zip;

namespace SeriesTracker
{
    class ApiReader
    {
        private const string API_KEY = "0C5FF0165A8AFFAD";

        private List<String> xmlMirrors     = new List<String>();
        private List<String> bannerMirrors  = new List<String>();
        private List<String> zipMirrors     = new List<String>();

        public ApiReader()
        {
            ParseMirrors();
        }

        public string GetMirrorUrl()
        {
            return "http://www.thetvdb.com/api/" + API_KEY +"/mirrors.xml";
        }

        public string GetSeriesUrl(String seriesName)
        {
            return "http://www.thetvdb.com/api/GetSeries.php?seriesname=" + seriesName;
        }

        public string GetZipUrl(int seriesId)
        {
            return zipMirrors[0] + "/api/" + API_KEY + "/series/" + seriesId.ToString() + "/all/en.zip";
        }

        private void ParseMirrors()
        {
            XDocument doc = XDocument.Load(GetMirrorUrl());
            xmlMirrors.Clear();
            bannerMirrors.Clear();
            zipMirrors.Clear();
            var mirrors = from mirror in doc.Descendants("Mirror")
                            select new
                            {
                                id          = mirror.Element("id").Value,
                                mirrorpath  = mirror.Element("mirrorpath").Value,
                                typemask    = mirror.Element("typemask").Value,
                            }; 

            foreach (var mirror in mirrors)
            {
                for( int xml = 0; xml <= 1; xml++)
                    for( int zip = 0; zip <= 1; zip++)
                        for( int banner = 0; banner <= 1; banner++)
                            if( (xml * 1 + zip * 2 + banner * 4) == Convert.ToInt32(mirror.typemask))
                            {
                                if (xml == 1)
                                    xmlMirrors.Add(mirror.mirrorpath);
                                if (banner == 1)
                                    bannerMirrors.Add(mirror.mirrorpath);
                                if (zip == 1)
                                    zipMirrors.Add(mirror.mirrorpath);
                            }
            }
        }

        public List<Serie> GetSeriesFromName(String name)
        {
            XDocument doc = XDocument.Load(GetSeriesUrl(name));
            var series = from serie in doc.Descendants("Series")
                         where serie.Element("SeriesName") != null && serie.Element("id") != null 
                          select new Serie
                          {
                              Name = serie.Element("SeriesName").Value,
                              Overview = serie.Element("Overview") != null ? serie.Element("Overview").Value : "",
                              Id = Convert.ToInt32(serie.Element("id").Value)
                          };
            return series.ToList();
        }

        public List<Episode> GetAllEpisodes(int seriesId)
        {
            String zipPath = System.IO.Path.GetTempPath() + "en.zip";
            String unzipPath = System.IO.Path.GetTempPath() + "seriestracker unzip";
            String xmlPath = unzipPath + System.IO.Path.DirectorySeparatorChar + "en.xml";
            System.Net.WebClient client = new System.Net.WebClient();
            client.DownloadFile(GetZipUrl(seriesId), zipPath);
            using (ZipFile zip = ZipFile.Read(zipPath))
            {
                foreach (ZipEntry e in zip)
                {
                    e.Extract(unzipPath, ExtractExistingFileAction.OverwriteSilently);
                }
            }
            XDocument doc = XDocument.Load(xmlPath);
            var episodes = from episode in doc.Descendants("Episode")
                            where episode.Element("EpisodeName") != null && episode.Element("id") != null &&
                                  episode.Element("SeasonNumber") != null && episode.Element("EpisodeNumber") != null
                            select new Episode
                            {
                                Name = episode.Element("EpisodeName").Value,
                                Overview = episode.Element("Overview") != null ? episode.Element("Overview").Value : "",
                                Id = Convert.ToInt32(episode.Element("id").Value),
                                SeasonNumber = Convert.ToInt32(episode.Element("SeasonNumber").Value),
                                EpisodeNumber = Convert.ToInt32(episode.Element("EpisodeNumber").Value),
                                SeriesId = Convert.ToInt32(episode.Element("seriesid").Value),
                                FirstAired = Episode.DateToTimestamp(episode.Element("FirstAired").Value)
                            };
            
            return episodes.ToList();
        }

    }
}
