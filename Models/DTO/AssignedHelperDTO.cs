using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompetitionManager.Models.DTO
{
    public class AssignedHelperDTO
    {
        public int HelperID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Assigned { get; set; }
    }
}