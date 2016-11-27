namespace HW8.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PirateUnionContext : DbContext
    {
        public PirateUnionContext()
            : base("name=PirateUnionContext")
        {
        }

        public virtual DbSet<Crew> Crews { get; set; }
        public virtual DbSet<Pirate> Pirates { get; set; }
        public virtual DbSet<Ship> Ships { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Crew>()
                .Property(e => e.Booty)
                .HasPrecision(19, 2);

            modelBuilder.Entity<Pirate>()
                .HasMany(e => e.Crews)
                .WithRequired(e => e.Pirate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ship>()
                .HasMany(e => e.Crews)
                .WithRequired(e => e.Ship)
                .WillCascadeOnDelete(false);
        }
    }
}
