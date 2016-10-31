using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HW5.Models
{
    public class Request
    {
        [Display(Name = "V#:"),DisplayFormat(DataFormatString = "{0:D8}"), Required]
        public int VNo { get; set; }

        [Display(Name = "Last Name:"), Required]
        public string LastName { get; set; }

        [Display(Name = "First Name:"), Required]
        public string FirstName { get; set; }

        [Display(Name = "Date:"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}"), Required]
        public DateTime Date { get; set; }

        [Display(Name = "Phone Number:"),DisplayFormat(DataFormatString = "{0:###-###-####}"),Required]
        public long PhoneNumber { get; set; }

        [Display(Name = "Catalog Year:"),Required]
        public string CatalogYear { get; set; }

        [Display(Name = "Email:"), Required]
        public string Email { get; set; }

        [Display(Name = "Major:"), Required]
        public string Major { get; set; }

        [Display(Name = "Minor:"), Required]
        public string Minor { get; set; }

        [Display(Name = "Advisor:"), Required]
        public string Advisor { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}; VNo = {"V" + VNo} {LastName} {FirstName} {Date} {PhoneNumber} {CatalogYear} {Email} {Major} {Minor} {Advisor}";
        }
    }
}