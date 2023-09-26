using Microsoft.AspNetCore.Mvc;
using CarService;
using CarModels;
using System.Net;

namespace CarManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IAddCar _addCar;
        private readonly IGetCars _getCars;

        public CarsController(IAddCar addCar, IGetCars getCars)
        {
            _addCar = addCar;
            _getCars = getCars;
        }

        [HttpPost]
        public async Task<int> AddCar(CarDTO car)
        {
            var data = await _addCar.AddCar(car);
            return data;
        }

        [HttpGet]
        public async Task<ActionResult<List<CarDTO>>> GetCars([FromQuery] Filter filters )
        {
            var data = await _getCars.GetCars(filters);
            if (data == null || data.Count==0)
                return NoContent();
            else
                return Ok(data);
        }
    }
}
