using Microsoft.EntityFrameworkCore;
using PharmacyWeb.Shared.Models;

namespace PharmacyWeb.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        public DataContext(DbContextOptions options) : base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = tcp:pharmacyproject.database.windows.net, 1433; Initial Catalog = PharmacyProject; Persist Security Info = False; User ID = Maflend; Password = PhPr34912; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
        }
    }
}
