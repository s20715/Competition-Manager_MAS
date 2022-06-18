using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompetitionManager.Models
{
    public class Player : Participant
    {
        
        public string Role { get; set; }
        public Partnership Partnership { get; set; }
    }
}