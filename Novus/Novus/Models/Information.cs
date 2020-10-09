using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Novus.Models
{
    public class Information
    {
        [PrimaryKey, AutoIncrement]
        public int InformationID { get; set; }
        public string Line { get; set; }

        public Information(string Line)
        {
            this.Line = Line;
        }

        public Information()
        {

        }
    }
}
