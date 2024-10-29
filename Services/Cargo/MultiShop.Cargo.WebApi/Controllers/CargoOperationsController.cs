using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDto;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoDetailService;

        public CargoOperationsController(ICargoOperationService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoOperationsList()
        {
            return Ok(_cargoDetailService.TGetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            return Ok(_cargoDetailService.TGetById(id));
        }

        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                Barcode = createCargoOperationDto.Barcode,
                Description = createCargoOperationDto.Description,
                OperationDate = createCargoOperationDto.OperationDate
            };
            _cargoDetailService.TInsert(cargoOperation);
            return Ok("Cargo Operation Added");
        }

        [HttpDelete]
        public IActionResult RemoveCargoOperation(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Cargo Operation Deleted");
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                CargoOperationId = updateCargoOperationDto.CargoOperationId,
                Barcode = updateCargoOperationDto.Barcode,
                Description = updateCargoOperationDto.Description,
                OperationDate = updateCargoOperationDto.OperationDate
            };
            _cargoDetailService.TUpdate(cargoOperation);
            return Ok("Cargo Operation Updated");
        }
    }
}
