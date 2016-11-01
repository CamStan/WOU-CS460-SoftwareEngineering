using HW5.Models;
using System.Data.Entity;

namespace HW5.DAL
{
    public class RequestContext : DbContext
    {
        /// <summary>
        /// Pulls the data out of Requests table in 460_HW5 database, wraps each
        /// row in a Request object, and stores them in the DbSet.
        /// </summary>
        public DbSet<Request> Requests { get; set; }
    }
}