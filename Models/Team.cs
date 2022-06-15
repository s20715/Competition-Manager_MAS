using CompetitionManager.DAL;
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

        public static int MaxPlayers { get {
                return 6;
            }  }
        public static int MinPlayers { get {
                return 5;
            } }
        private Captain captain;
        public virtual Captain Captain { get {
                return captain;
            } 
            set {
                if (Partnerships.Any(x => x.Player.ID == value.ID))
                    throw new Exception("XOR exception");
                else
                    captain = value;
            } }
        public virtual ICollection<Partnership> Partnerships { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }
}