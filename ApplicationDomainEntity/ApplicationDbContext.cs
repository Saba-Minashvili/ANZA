using ApplicationDomainModels.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationDomainEntity
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Account> AccountDb { get; set; }
        public DbSet<ShippingAddress> ShippingAddressDb { get; set; }
        public DbSet<Contact> ContactDb { get; set; }
        public DbSet<Address> AddressDb { get; set; }
        public DbSet<Item> ItemDb { get; set; }
        public DbSet<LikedItem> LikedItemsDb { get; set; }
        public DbSet<MaterialType> MaterialTypesDb { get; set; }
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=DESKTOP-0FM65T2;Database=ANZA;Trusted_Connection=true;MultipleActiveResultSets=true");
        }
    }
}
