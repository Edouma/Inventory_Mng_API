using Inventory_Mngt_API.Models.Domain;

namespace Inventory_Mngt_API.Repositories
{
    public interface IProductRepository
    {
        Task<ProductsModel> CreateAsync(ProductsModel product);
    }
}
