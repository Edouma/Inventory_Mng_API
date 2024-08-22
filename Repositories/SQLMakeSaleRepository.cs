using Inventory_Mngt_API.Data;
using Inventory_Mngt_API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Mngt_API.Repositories
{
    public class SQLMakeSaleRepository : IMakeSaleRepository
    {
        private readonly InventoryDbContext inventoryDbContext;

        public SQLMakeSaleRepository(InventoryDbContext inventoryDbContext)
        {
            this.inventoryDbContext = inventoryDbContext;
        }

        //public async Task<MakeSaleModel> CreateAsync(MakeSaleModel sale)
        //{
        //    await inventoryDbContext.Sales.AddAsync(sale);
        //    await inventoryDbContext.SaveChangesAsync();
        //    return sale;
        //}

        public async Task<MakeSaleModel> CreateAsync(MakeSaleModel sale)
        {
            var product = await inventoryDbContext.Products.FindAsync(sale.ProductId);

            if (product == null)
            {
                throw new Exception("Product not found"); // Handle this more gracefully in a real-world app
            }

            // Check if the product has enough quantity
            if (product.Quantity < sale.Quantity)
            {
                throw new Exception("Insufficient quantity available");
            }

            // Reduce the product's quantity
            product.Quantity -= sale.Quantity;

            await inventoryDbContext.Sales.AddAsync(sale);
            await inventoryDbContext.SaveChangesAsync();

            return sale;
        }

        public async Task<List<MakeSaleModel>> GetAllAsync()
        {
            //return await inventoryDbContext.Sales.Include("Product").ToListAsync();
            return await inventoryDbContext.Sales
        .Include(s => s.Product) // Ensure the Product is included
        .ToListAsync();
        }


    }
}
//return await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();