using Inventory_Mngt_API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Mngt_API.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<ProductsModel> Products { get; set; }
        public DbSet<MakeSaleModel> Sales { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure one-to-many relationship
            modelBuilder.Entity<MakeSaleModel>().HasOne(s => s.Product).WithMany(p => p.Sales).HasForeignKey(s => s.ProductId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
