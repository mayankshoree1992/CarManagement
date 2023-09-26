using CarModels;

namespace CarService
{
    public interface IGetCars
    {
        Task<List<CarDTO>> GetCars(Filter filters);
    }
}
