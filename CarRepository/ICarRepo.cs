using CarModels;

namespace CarRepository
{
    public interface ICarRepo
    {
        public Task<Car> AddCar(Car car);
        Task<List<Car>> GetCars(string filter);
    }
}
