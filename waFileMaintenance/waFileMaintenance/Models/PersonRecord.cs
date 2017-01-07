using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace waFileMaintenance.Models
{
    [MetadataType(typeof(PersonRecordMetadata))]
    public partial class tblPersonRecord
    {
    }

    public class PersonRecordMetadata
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public Nullable<System.DateTime> DateOfBirth { get; set; }

        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
    }
}