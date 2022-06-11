using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompetitionManager.Models
{
    public class Rulebook
    {
        [ForeignKey("Competition")]
        public int ID { get; set; }
        public string Description { get; set; }
        public List<string> Creators { get; set; }
        public virtual Competition Competition { get; set; }
    }
}