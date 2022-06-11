using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompetitionManager.Models
{
    public class Match
    {

        public int ID { get; set; }
        public string Form { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }
        public string Status { get; set; }
        public virtual Team Team1 { get; set; }
        public virtual Team Team2 { get; set; }
        public virtual Helper Referee { get; set; }
        public virtual Competition Competition { get; set; }
    }
}