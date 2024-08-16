using Inventory_Mngt_API.Models.Domain;

namespace Inventory_Mngt_API.Repositories
{
    public class SQLProductRepository : IProductRepository
    {
        public Task<ProductsModel> CreateAsync(ProductsModel product)
        {
            throw new NotImplementedException();
        }
    }
}
