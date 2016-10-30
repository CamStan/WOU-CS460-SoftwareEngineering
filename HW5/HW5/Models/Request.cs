using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HW5.Models
{
    public class Request
    {
        [Display(Name = "V#"), Required]
        public int VNo { get; set; }

        [Display(Name = "Last Name"), Required]
        public string LastName { get; set; }

        [Display(Name = "First Name"), Required]
        public string FirstName { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:mm/dd/yyyy}"), Required]
        public DateTime Date { get; set; }

        [DisplayFormat(DataFormatString = "{0:###-###-####}"),Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string CatalogYear { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Major { get; set; }

        [Required]
        public string Minor { get; set; }

        [Required]
        public string Advisor { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}; VNo = V + {VNo} {LastName} {FirstName} {Date} {PhoneNumber} {CatalogYear} {Email} {Major} {Minor} {Advisor}";
        }
    }
}