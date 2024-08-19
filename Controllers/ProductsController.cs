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
        public async Task <IActionResult> Create([FromBody] AddProductRequestDto addProductRequestDto )
        {
            //map DTO to domain model
            var productDomainModel = mapper.Map<ProductsModel>(addProductRequestDto);

            productDomainModel = await productRepository.CreateAsync(productDomainModel);

            //Map Domain model to DTO
            return Ok(mapper.Map<ProductsDto>(productDomainModel));

        }

        [HttpGet]
        public async Task <IActionResult> GetAll() 
        { 
            var productsDomainModel = await productRepository.GetAllAsync();

            var productsDto = mapper.Map<List<ProductsModel>>(productsDomainModel);

            return Ok(productsDto);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task <IActionResult> GetById([FromRoute] Guid id)
        {
            //Get product domain modal from database
            var productDomain = await productRepository.GetByIdAsync(id);

            if (productDomain == null)
            {
                return NotFound();
            }

            var productDTO = mapper.Map<ProductsDto>(productDomain);
            return Ok(productDTO);
        }
        [HttpDelete]
        [Route("{id: Guid}")]
        public async Task<IActionResult> DeleteAync([FromRoute] Guid id)
        {
            var productDomain = await productRepository.DeleteAsync(id);

            if (productDomain == null)
            {
                return NotFound();
            }

            //Map domain model to DTO
            var productDto = mapper.Map<ProductsDto>(productDomain);

            return Ok(productDto);
        }
    }
}
