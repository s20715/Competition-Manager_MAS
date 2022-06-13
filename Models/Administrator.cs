using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompetitionManager.Models
{
    public abstract class Administrator : Person
    {
        [StringLength(11)]
        [Index(IsUnique = true)]
        public string PESEL { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        
    }
}