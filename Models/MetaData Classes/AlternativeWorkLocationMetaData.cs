using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tikti.Models
{
    [ModelMetadataTypeAttribute(typeof(AlternativeWorkLocationMetaData))]
    public partial class AlternativeWorkLocation
    { }
    public class AlternativeWorkLocationMetaData
    {
       

        public int WorkLocationId { get; set; }

        [Required(ErrorMessage ="The Field named city is required")]
        public string City { get; set; }

        [Display(Name ="Province / State")]
        [Required(ErrorMessage = "The Field Province/State is required")]
        public string Province { get; set; }
        
        
        [Required(ErrorMessage = "The Field Postal code is required")]
        public string Postal { get; set; }
    }
}
