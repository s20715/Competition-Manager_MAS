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
        private ICollection<BagContribution> bagContributions;
        [Required]//tutaj tak ciekawie dlatego że na diagramie wstawiłem tą relację jako zero or one to many a nie many to many dlatego sprawdzam czy jedno contribution nie idzie do dwóch competition
        public ICollection<BagContribution> BagContributions { get; set; }
        /*
        public ICollection<BagContribution> BagContributions { get 
            {
                return bagContributions;
            }
            set 
            {
                if (value.Count > 1)
                {
                    int cId = value.First().ComptetitionID;
                    foreach(BagContribution bg in value)
                    {
                        if (bg.ComptetitionID != cId)
                        {
                            //value.Remove(bg);//?
                            throw new Exception("Bag exception");//?
                        }
                    }
                    bagContributions = value;
                }
            } 
        }
        */
    }
}