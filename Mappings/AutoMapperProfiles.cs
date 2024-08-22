using AutoMapper;
using Inventory_Mngt_API.Models.Domain;
using Inventory_Mngt_API.Models.DTO;

namespace Inventory_Mngt_API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ProductsModel, ProductsDto>().ReverseMap();
            CreateMap<ProductsModel, AddProductRequestDto>().ReverseMap();
            CreateMap<ProductsModel, UpdateProductRequestDto>().ReverseMap();

            CreateMap<MakeSaleModel, MakeSaleDto>().ReverseMap();
        }

    }
}
