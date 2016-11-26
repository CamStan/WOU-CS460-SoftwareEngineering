using System.Data.Entity;
using HW7.Models;

namespace HW7.DAL
{
    public class StockRequestContext : DbContext
    {
        public DbSet<StockRequest> StockRequests { get; set; }
    }
}