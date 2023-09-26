using CarModels;

namespace CarService
{
    public interface IAddCar
    {
        public Task<int> AddCar(CarDTO carDTO);

    }
}
