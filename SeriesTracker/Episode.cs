using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriesTracker
{
    class Episode
    {
        private String name;
        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        private int seriesId;
        public int SeriesId
        {
            get
            {
                return seriesId;
            }
            set
            {
                seriesId = value;
            }
        }

        private String overview;
        public String Overview
        {
            get
            {
                return overview;
            }
            set
            {
                overview = value;
            }
        }

        private int seasonNumber;
        public int SeasonNumber
        {
            get
            {
                return seasonNumber;
            }
            set
            {
                seasonNumber = value;
            }
        }

        private int episodeNumber;
        public int EpisodeNumber
        {
            get
            {
                return episodeNumber;
            }
            set
            {
                episodeNumber = value;
            }
        }

        private int firstAired;
        public int FirstAired
        {
            get
            {
                return firstAired;
            }
            set
            {
                firstAired = value;
            }
        }

        private Boolean seen = false;
        public Boolean Seen
        {
            get
            {
                return seen;
            }
            set
            {
                seen = value;
            }
        }

        public static int DateToTimestamp(String date)
        {
            String[] splitted = date.Split(new string[]{"-"}, StringSplitOptions.RemoveEmptyEntries);
            if (splitted.Length < 3) return -1;
            DateTime now = new DateTime(Convert.ToInt32(splitted[0]), Convert.ToInt32(splitted[1]), Convert.ToInt32(splitted[2]));
            TimeSpan t = (now - new DateTime(1970, 1, 1).ToLocalTime());
            int timestamp = (int)t.TotalSeconds;
            return timestamp;
        }

        public void save()
        {
            Database db = new Database();
            db.insertEpisode(Id, SeriesId, Name, Overview, EpisodeNumber, SeasonNumber, FirstAired, Seen);
        }

        public override String ToString()
        {
            return Name;
        }

    }
}
