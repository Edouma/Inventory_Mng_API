using Inventory_Mngt_API.Models.Domain;

namespace Inventory_Mngt_API.Repositories
{
    public interface IMakeSaleRepository
    {
        Task<MakeSaleModel> CreateAsync(MakeSaleModel sale);
        Task<List<MakeSaleModel>> GetAllAsync();
    }
}
