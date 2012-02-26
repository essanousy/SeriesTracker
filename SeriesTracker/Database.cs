using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace SeriesTracker
{
    class Database
    {

        private String dbPath = "c:\\data.db";

        public Database()
        { 
        
        }

        public SQLiteDatabase getDb()
        {
            return new SQLiteDatabase(dbPath);
        }

        public void insertSerie(int id, String name, String overview)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.CommandText = "INSERT OR REPLACE INTO series (id, name, overview) VALUES( @id, @name, @overview )";
            cmd.Parameters.Add(new SQLiteParameter("@id", id));
            cmd.Parameters.Add(new SQLiteParameter("@name", name));
            cmd.Parameters.Add(new SQLiteParameter("@overview", overview));
            SQLiteDatabase db = getDb();
            db.ExecuteNonQuery(cmd);
        }

        public void insertEpisode(int id, int seriesId, String name, String overview, int episodeNumber, int seasonNumber, int firstAired, Boolean seen)
        { 
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.CommandText = "INSERT OR REPLACE INTO episodes (id, seriesid, name, overview, episode, season, firstaired, seen)" +
                              "VALUES(@id, @seriesid, @name, @overview, @episode, @season, @firstaired, @seen)";
            cmd.Parameters.Add(new SQLiteParameter("@id", id));
            cmd.Parameters.Add(new SQLiteParameter("@seriesid", seriesId));
            cmd.Parameters.Add(new SQLiteParameter("@name", name));
            cmd.Parameters.Add(new SQLiteParameter("@overview", overview));
            cmd.Parameters.Add(new SQLiteParameter("@episode", episodeNumber));
            cmd.Parameters.Add(new SQLiteParameter("@season", seasonNumber));
            cmd.Parameters.Add(new SQLiteParameter("@firstaired", firstAired));
            cmd.Parameters.Add(new SQLiteParameter("@seen", seen));
            SQLiteDatabase db = getDb();
            db.ExecuteNonQuery(cmd);
        }

        public List<Serie> getAllSeries()
        {
            List<Serie> result = new List<Serie>();
            /*
            SQLiteDatabase db = getDb();
            DataTable dt = db.GetDataTable("SELECT * FROM series");
            foreach (DataRow row in dt.Rows)
            {
                Serie serie = new Serie();
                serie.Id = row.Field<Int32>(0);
                serie.Name = row.Field<String>("name");
                serie.Overview = row.Field<String>("overview");
                result.Add(serie);
            }
             */
            SQLiteDatabase db = getDb();
            SQLiteDataReader reader = db.GetDataReader("SELECT * FROM series");
            while (reader.Read())
            {
                Serie serie = new Serie();
                serie.Id = reader.GetInt32(reader.GetOrdinal("id"));
                serie.Name = reader.GetString(reader.GetOrdinal("name"));
                serie.Overview = reader.GetString(reader.GetOrdinal("overview"));
                result.Add(serie);
            }
            return result;
        }
    }
}
