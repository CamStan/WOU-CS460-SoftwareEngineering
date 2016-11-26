using System.Data.Entity;
using HW7.Models;

namespace HW7.DAL
{
    /// <summary>
    /// Creates access to the CS460_HW7 database in order to manipulate and view the tables
    /// and data therein.
    /// </summary>
    public class StockRequestContext : DbContext
    {
        /// <summary>
        /// Creates access to the StockRequests table for creation and view of the data in
        /// this table by wrapping each row in a StockRequest object.
        /// </summary>
        public DbSet<StockRequest> StockRequests { get; set; }
    }
}