using Microsoft.EntityFrameworkCore;
using System.Configuration;
using FleetManagement.Models;


namespace FleetManagement.DAL
{


    public class MyDbContext : DbContext
    {

        public string ConnectionString = "";


        public MyDbContext() : base()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["MyDbContext"].ConnectionString.ToString();

        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["MyDbContext"].ConnectionString.ToString();


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DutyViewModel>()
                .HasOne(e => e.V_DriversVM)
                .WithMany(e => e.Duties)
                .HasForeignKey(e => e.DriverId)
                .IsRequired();

            modelBuilder.Entity<DriverViewModel>()
                .HasMany<DutyViewModel>(s => s.Duties);

            modelBuilder.Entity<VehicleViewModel>()
                .HasOne(e => e.V_VehicleDriversVM);
               

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(ConnectionString);


        public DbSet<DriverViewModel> Drivers { get; set; }
        public DbSet<DutyViewModel> Duties { get; set; }
        public DbSet<UserViewModel> Users { get; set; }

        public DbSet<VehicleViewModel> Vehicles { get; set; }

    }
}
