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

        [NotMapped]
        public  int MaxPlayers { get {
                if (Matches.FirstOrDefault<Match>() != null)
                {
                    if (Matches.FirstOrDefault<Match>().Competition.GameID == 4)
                        return 4;
                }
                return 6;
            }  }
        [NotMapped]
        public int MinPlayers { get {
                if (Matches.FirstOrDefault<Match>() != null)
                {
                    if (Matches.FirstOrDefault<Match>().Competition.GameID == 4)
                        return 3;
                }
                return 5;
            } }
        private Captain captain;
        public virtual Captain Captain { get {
                return captain;
            } 
            set {
                if (Partnerships.Any(x => x.Player.Email.ToLower() == value.Email.ToLower()))
                    throw new Exception("XOR exception");
                else
                    captain = value;
            } }
        public virtual ICollection<Partnership> Partnerships { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }
}