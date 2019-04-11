using System.Data.Entity;

namespace CrudOnDb_MVC.Models
{
    public partial class TourismDB : DbContext
    {
        public TourismDB()
            : base("name=TourismDB")
        {
        }

        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Hotels> Hotels { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Tour_point> Tour_point { get; set; }
        public virtual DbSet<Tours> Tours { get; set; }
        public virtual DbSet<Transports> Transports { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clients>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Clients>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Clients>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Clients)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employees>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Employees>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Tours>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Tours)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tours>()
                .HasMany(e => e.Tour_point)
                .WithRequired(e => e.Tours)
                .WillCascadeOnDelete(false);
        }
    }
}
