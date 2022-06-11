using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompetitionManager.Models
{
    public class Contribution
    {
        public int ID { get; set; }
        public decimal Amount { get; set; }
        public string Contributor { get; set; }
        public virtual Competition Competition { get; set; }
    }
}