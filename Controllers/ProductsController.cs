using AutoMapper;
using Inventory_Mngt_API.Models.Domain;
using Inventory_Mngt_API.Models.DTO;
using Inventory_Mngt_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Mngt_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpPost]
        public async Task <IActionResult> Create([FromBody] AddProductsDto productsDto, IMapper mapper)
        {
            //map DTO to domain model
            var productDomainModel = mapper.Map<ProductsModel>(productsDto);

            productDomainModel = await productRepository.CreateAsync(productDomainModel);

            //Map Domain model to DTO
            return Ok(mapper.Map<AddProductsDto>(productDomainModel));

        }
    }
}
