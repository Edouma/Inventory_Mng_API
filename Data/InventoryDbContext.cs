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
    }
}
