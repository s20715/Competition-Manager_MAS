using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompetitionManager.Models
{
    public class Contribution
    {
        public int ID { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string Contributor { get; set; }
        [Required]
        public virtual Competition Competition { get; set; }
    }
}