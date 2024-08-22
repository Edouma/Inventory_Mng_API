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
    public class MakeSaleController : ControllerBase
    {
        private readonly IMakeSaleRepository makeSaleRepository;
        private readonly IMapper mapper;

        public MakeSaleController(IMakeSaleRepository makeSaleRepository, IMapper mapper)
        {
            this.makeSaleRepository = makeSaleRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MakeSaleDto makeSaleDto)
        {
            //map DTO to domain model
            var saleDomainModel = mapper.Map<MakeSaleModel>(makeSaleDto);

            saleDomainModel = await makeSaleRepository.CreateAsync(saleDomainModel);

            //Map Domain model to DTO
            return Ok(mapper.Map<MakeSaleDto>(saleDomainModel));

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var salesDomainModel = await makeSaleRepository.GetAllAsync();

            var salesDto = mapper.Map<List<DisplaySaleDto>>(salesDomainModel);

            return Ok(salesDto);
        }

    }
}
