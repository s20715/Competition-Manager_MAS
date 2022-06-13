using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompetitionManager.Models
{
    public class Creator
    {
        //[ForeignKey("Captain")]
        public int ID { get; set; }
        public string CreatorName { get; set; }
    }
}