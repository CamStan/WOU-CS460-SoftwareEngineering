namespace HW8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Crew
    {
        public int ID { get; set; }

        public int PirateID { get; set; }

        public int ShipID { get; set; }

        public decimal Booty { get; set; }

        public virtual Pirate Pirate { get; set; }

        public virtual Ship Ship { get; set; }
    }
}
