using HW8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW8.ViewModels
{
    /// <summary>
    /// ViewModel to package and send all ships and crews to a view
    /// </summary>
    public class ShipCrews
    {
        public List<Ship> TheShips { get; set; }
        public List<Crew> TheCrews { get; set; }
    }
}