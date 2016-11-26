using System;
using System.ComponentModel.DataAnnotations;

namespace HW7.Models
{
    public class StockRequest
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Stock Symbol")]
        public string StockSymbol { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "IP Address")]
        public string IP_Address { get; set; }

        [Required]
        public string Browser { get; set; }
    }
}