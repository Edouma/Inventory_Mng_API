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
        private readonly IMapper mapper;

        public ProductsController(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task <IActionResult> Create([FromBody] AddProductsDto productsDto )
        {
            //map DTO to domain model
            var productDomainModel = mapper.Map<ProductsModel>(productsDto);

            productDomainModel = await productRepository.CreateAsync(productDomainModel);

            //Map Domain model to DTO
            return Ok(mapper.Map<AddProductsDto>(productDomainModel));

        }

        [HttpGet]
        public async Task <IActionResult> GetAll() 
        { 
            var productsDomainModel = await productRepository.GetAllAsync();

            var productsDto = mapper.Map<List<ProductsModel>>(productsDomainModel);

            return Ok(productsDto);
        }
    }
}
