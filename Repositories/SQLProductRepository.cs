using Inventory_Mngt_API.Data;
using Inventory_Mngt_API.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ProductsModel?> DeleteAsync(Guid id)
        {
            var existingProduct = await inventoryDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (existingProduct == null) 
            {
                 return null;
            }
             inventoryDbContext.Products.Remove(existingProduct);
             await inventoryDbContext.SaveChangesAsync();

            return existingProduct;
        }

        public async Task<List<ProductsModel>> GetAllAsync()
        {
           return  await inventoryDbContext.Products.ToListAsync();
        }

        public async Task<ProductsModel?> GetByIdAsync(Guid id)
        {
            
            var response = await inventoryDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (response == null) 
            {
                return null;
            }

            return response;
        }
    }
}
