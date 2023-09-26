using CarModels;
using CarRepository;

namespace CarService
{
    public class AddCarService : IAddCar
    {
        private readonly ICarRepo _carRepo;
        
        public AddCarService(ICarRepo carRepo)
        {
          _carRepo = carRepo;
        }
        public async Task<int> AddCar(CarDTO carDTO)
        {
            Car car = new Car()
            {
                Id = carDTO.Id,
                BodyType = carDTO.BodyType,
                Brand = carDTO.Brand,
                CarName = carDTO.CarName,
                Color = carDTO.Color,
                FuelType = carDTO.FuelType,
                Model = carDTO.Model,
                Price = carDTO.Price,
                SeatCapacity = carDTO.SeatCapacity,
                Transmition = carDTO.Transmition
            };
            var a =  await _carRepo.AddCar(car);
            return a.Id;
        }
    }
}
