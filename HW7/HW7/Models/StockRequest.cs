using System;
using System.ComponentModel.DataAnnotations;

namespace HW7.Models
{
    /// <summary>
    /// A single StockRequest ojbect to represent a row from the StockRequests table for
    /// logging stock symbol requests made to this application. Each object has an ID,
    /// text of the symbol requested, datetime the request was made, the IP Address the
    /// request was made from, and the web browser used to make the request.
    /// </summary>
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