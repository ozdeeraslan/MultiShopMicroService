using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDto;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;
        public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            return Ok(_cargoCompanyService.TGetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id)
        {
            return Ok(_cargoCompanyService.TGetById(id));
        }

        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                CargoCompanyName=createCargoCompanyDto.CargoCompanyName
            };
            _cargoCompanyService.TInsert(cargoCompany);
            return Ok("Cargo Company Added");
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                CargoCompanyId=updateCargoCompanyDto.CargoCompanyId,
                CargoCompanyName=updateCargoCompanyDto.CargoCompanyName
            };
            _cargoCompanyService.TUpdate(cargoCompany);
            return Ok("Cargo Company Updated");
        }

        [HttpDelete]
        public IActionResult RemoveCargoCompany(int id)
        {
            _cargoCompanyService.TDelete(id);
            return Ok("Cargo Company Deleted");
        }


    }
}
