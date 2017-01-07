using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace waFileMaintenance.Models
{
    [MetadataType(typeof(GenderMetadata))]
    public partial class Gender
    {
    }

    public class GenderMetadata
    {
        [Display(Name = "Gender")]
        public string Gender { get; set; }
    }
}