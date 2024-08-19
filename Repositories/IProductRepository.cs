using Inventory_Mngt_API.Models.Domain;

namespace Inventory_Mngt_API.Repositories
{
    public interface IProductRepository
    {
        Task<ProductsModel> CreateAsync(ProductsModel product);
        Task<List<ProductsModel>> GetAllAsync();
        Task<ProductsModel?> GetByIdAsync(Guid id);
        Task<ProductsModel?> DeleteAsync(Guid id);
        Task<ProductsModel?> UpdateAsync(Guid id, ProductsModel products);
    }
}
