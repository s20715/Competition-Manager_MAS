using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompetitionManager.Models
{
    public class Captain : Player
    {
        public int TelephoneNumber { get; set; }
        public virtual Team Team { get; set; }
    }
}