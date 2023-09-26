using CarRepository;
using CarModels;

namespace CarService
{
    public class GetCarsService : IGetCars
    {
        private readonly ICarRepo _carRepo;

        public GetCarsService(ICarRepo carRepo)
        {
            _carRepo = carRepo;
        }
        public async Task<List<CarDTO>> GetCars(Filter filters)
        {
            var cars = await _carRepo.GetCars(filters);
            if (cars != null)
            {
                List<CarDTO> result = new List<CarDTO>();

                foreach (var car in cars)
                {
                    var carDTO = new CarDTO()
                    {
                        Id = car.Id,
                        BodyType = car.BodyType,
                        Brand = car.Brand,
                        CarName = car.CarName,
                        Color = car.Color,
                        FuelType = car.FuelType,
                        Model = car.Model,
                        Price = car.Price,
                        SeatCapacity = car.SeatCapacity,
                        Transmition = car.Transmition
                    };
                    result.Add(carDTO);
                }

                return result;
            }
            else
            {

                return null;
            }
        }
    }
}
