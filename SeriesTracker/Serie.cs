using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriesTracker
{
    class Serie
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

        public void Save()
        {
            Database db = new Database();
            db.insertSerie(Id, Name, Overview);
        }

        public override Boolean Equals(Object obj)
        {
            Serie other = obj as Serie;
            if ((Object)other == null)
                return false;
            else
                return this.Id == other.Id; 
        }

        public override String ToString()
        {
            return Name;
        }
    }

}
