using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompetitionManager.Models
{
    public class BagContribution
    {
        public int ID { get; set; }
        
        public int ContributionID { get; set; }
        public int ComptetitionID { get; set; }
        [Required]
        public Competition Competition { get; set; }
       
        public Contribution Contribution { get; set; }
    }
}