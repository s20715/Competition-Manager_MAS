using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [NotMapped]
        public List<string> Creators { 
            get {
                return CreatorsString.Split(';').ToList<string>();
            } 
            set {
                string creatorsString = "";
                foreach(string s in value)
                {
                    creatorsString += s + ';';
                }
                creatorsString.Remove(creatorsString.Length - 1);
                CreatorsString = creatorsString;
            } 
        }
        [Required]
        public string CreatorsString { get; set; }



        public virtual Competition Competition { get; set; }
    }
}