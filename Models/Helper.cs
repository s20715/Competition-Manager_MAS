using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompetitionManager.Models
{
    public class Helper : Administrator
    {
        public Helper()
        {
            this.Competitions = new HashSet<Competition>();
            this.Matches = new HashSet<Match>();
        }
        public virtual ICollection<Competition> Competitions { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }
}