using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompetitionManager.Models
{
    public class Competition
    {
        //https://www.entityframeworktutorial.net/code-first/configure-many-to-many-relationship-in-code-first.aspx
        public Competition()
        {
            this.Helpers = new HashSet<Helper>();
            this.Matches = new HashSet<Match>();
            this.Contributions = new List<Contribution>();
        }
        public int ID { get; set; }
        public Game Game { get; set; }
        [DataType(DataType.Date)]
        public DateTime RegistrationStartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? RegistrationEndDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public string CurrentCompetitionState { get; set; }
        public virtual Rulebook Rulebook { get; set; }
        public virtual MainOrganizer MainOrganizer { get; set; }

        public virtual ICollection<Helper> Helpers { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
        public virtual ICollection<Contribution> Contributions { get; set; }

    }
}