using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompetitionManager.Models
{
    public class Organisation
    {
        [ForeignKey("MainOrganizer")]
        public int OrganisationId { get; set; }
        public string Name { get; set; }
        public List<int> TelephoneNumbers { get; set; }
        [Required]
        public virtual MainOrganizer MainOrganizer { get; set; }
        /*
         * Note: Student includes the StudentAddress navigation property and StudentAddress includes the Student navigation property.
         * With the one-to-zero-or-one relationship, a Student can be saved without StudentAddress but the StudentAddress 
         * entity cannot be saved without the Student entity. EF will throw an exception if you try to save the StudentAddress entity without the Student entity.
         * https://www.entityframeworktutorial.net/code-first/configure-one-to-one-relationship-in-code-first.aspx
         */
    }
}