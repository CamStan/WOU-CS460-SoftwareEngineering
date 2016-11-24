using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HW7.Models;

namespace HW7.DAL
{
    public class StockRequestContext : DbContext
    {
        public DbSet<StockRequest> StockRequests { get; set; }
    }
}