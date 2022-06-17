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
        public Participant(Guest _guest,string _email, DateTime _dateOfBirth)
        {
            FirstName = _guest.FirstName;
            LastName = _guest.LastName;
            Email = _email;
            DateOfBirth = _dateOfBirth;
        }
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}