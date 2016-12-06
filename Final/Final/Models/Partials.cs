using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final.Models
{
    public partial class Artist
    {
        [Display(Name = "Artist Name")]
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        [Display(Name = "Birth Place")]
        public string BirthPlace { get { return $"{BirthCity}, {BirthCountry}"; } }
    }
}