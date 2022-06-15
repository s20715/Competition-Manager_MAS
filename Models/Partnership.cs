using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompetitionManager.Models
{
    public class Partnership
    {
        [ForeignKey("Team")]
        public int TeamID { get; set; }
        [ForeignKey("Player")]
        public int ID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        private Team team;
        public virtual Team Team
        {
            get
            {
                return team;
            }
            set
            {
                if (player != null)
                {
                    if (player.ID == value.Captain.ID)
                    {
                        throw new Exception("XOR exception");
                    }
                }
                else
                {
                    team = value;
                }
            }
        }
    

        private Player player;
        public virtual Player Player { 
            get 
            {
                return player;
            } set 
            {
                if (team != null)
                {
                    if (team.Captain.ID == value.ID)
                    {
                        throw new Exception("XOR exception");
                    }
                }
                else
                {
                    player = value;
                }
            } }
    }
}