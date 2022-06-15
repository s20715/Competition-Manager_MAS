using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompetitionManager.Models
{
    public class Participant:Person
    {
        public Participant()
        {

        }
        public Participant(Guest guest,string email, DateTime DateOfBirth)
        {
            FirstName = guest.FirstName;
            LastName = guest.LastName;
        }
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}