using Inventory_Mngt_API.Data;
using Inventory_Mngt_API.Models.Domain;

namespace Inventory_Mngt_API.Repositories
{
    public class SQLProductRepository : IProductRepository
    {
        private readonly InventoryDbContext inventoryDbContext;

        public SQLProductRepository(InventoryDbContext inventoryDbContext)
        {
            this.inventoryDbContext = inventoryDbContext;
        }

        public async Task<ProductsModel> CreateAsync(ProductsModel product)
        {
            await inventoryDbContext.Products.AddAsync(product);
            await inventoryDbContext.SaveChangesAsync();
            return product;
        }
    }
}
