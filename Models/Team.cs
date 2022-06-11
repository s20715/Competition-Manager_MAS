using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompetitionManager.Models
{
    public class Team
    {
        //[ForeignKey("Captain")]
        public int ID { get; set; }
        public Team()
        {
            this.Partnerships = new HashSet<Partnership>();
            this.Matches = new HashSet<Match>();
        }
        public static int MaxPlayers { get; set; }
        public static int MinPlayers { get; set; }
        public virtual Captain Captain { get; set; }
        public virtual ICollection<Partnership> Partnerships { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }
}