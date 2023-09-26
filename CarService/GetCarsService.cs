using CarRepository;
using CarModels;
using System.Linq;

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
                return (from car in cars
                        let carDTO = new CarDTO()
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
                        }
                        select carDTO).ToList();
            }
            else
            {

               return new List<CarDTO>();
            }
        }
    }
}
