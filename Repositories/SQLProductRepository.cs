﻿using Inventory_Mngt_API.Data;
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

        public async Task<ProductsModel?> UpdateAsync(Guid id, ProductsModel products)
        {
            var existingProduct = await inventoryDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (existingProduct == null)
            {

                return null;
            }

            existingProduct.ProductName = products.ProductName;
            existingProduct.ProductDescription = products.ProductDescription;
            existingProduct.Price = products.Price;
            existingProduct.Quantity = products.Quantity;
            
            await inventoryDbContext.SaveChangesAsync();

            return existingProduct;
        }

        public async Task<ProductsModel> ReplenishStockAsync(Guid productId, int quantityToAdd)
        {
            var product = await inventoryDbContext.Products.FindAsync(productId);

            if (product == null)
            {
                throw new Exception("Product not found"); // Handle this more gracefully in a real-world app
            }

            // Add the quantity to the product's stock
            product.Quantity += quantityToAdd;

            await inventoryDbContext.SaveChangesAsync();

            return product;
        }

    }
}
