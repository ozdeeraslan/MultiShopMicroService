using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDto;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            return Ok(_cargoCustomerService.TGetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            return Ok(_cargoCustomerService.TGetById(id));
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Name = createCargoCustomerDto.Name,
                Surname = createCargoCustomerDto.Surname,
                Email = createCargoCustomerDto.Email,
                Phone = createCargoCustomerDto.Phone,
                Address = createCargoCustomerDto.Address,
                City = createCargoCustomerDto.City,
                District = createCargoCustomerDto.District
            };
            _cargoCustomerService.TInsert(cargoCustomer);
            return Ok("Cargo Customer Added");
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,
                Name = updateCargoCustomerDto.Name,
                Surname = updateCargoCustomerDto.Surname,
                Email = updateCargoCustomerDto.Email,
                Phone = updateCargoCustomerDto.Phone,
                Address = updateCargoCustomerDto.Address,
                City = updateCargoCustomerDto.City,
                District = updateCargoCustomerDto.District,
            };
            _cargoCustomerService.TUpdate(cargoCustomer);
            return Ok("Cargo Customer Updated");
        }

        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Cargo Customer Deleted");
        }
    }
}
