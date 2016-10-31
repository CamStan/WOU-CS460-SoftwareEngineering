using HW5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW5.DAL
{
    public class RequestCollection
    {
        public List<Request> theRequests;

        public RequestCollection()
        {
            theRequests = new List<Request>
            {
                new Request { VNo = 00000001, LastName = "Doe" ,FirstName = "John", Date = new DateTime(2016,10,30), PhoneNumber = 5551234567, CatalogYear = "2015-16", Email = "name@myemail.com", Major = "Computer Science", Minor = "Mathematics", Advisor = "Dr. Morse" }
            };
        }
    }
}