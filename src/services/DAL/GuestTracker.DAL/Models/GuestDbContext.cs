using GuestTracker.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GuestTracker.DAL.Models
{
    public class GuestDbContext:DbContext
    {
        public GuestDbContext(DbContextOptions<GuestDbContext> options) : base(options)
        {

        }
        //private IDbContextTransaction _transaction;

        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<VisitDetail> VisitDetails { get; set; }
    }
    public class TestEFDbContextFactory : IDesignTimeDbContextFactory<GuestDbContext>
    {
        public GuestDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GuestDbContext>();
            IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString,b => b.MigrationsAssembly("GuestTracker.Web"));

            return new GuestDbContext(optionsBuilder.Options);
        }
    }
}
