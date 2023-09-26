using Microsoft.EntityFrameworkCore;
using CarModels;
namespace CarRepository
{
    public class CarRepo : ICarRepo
    {
        private readonly Car_DbContext _DbContext;
        public CarRepo(Car_DbContext dbContext)
        {
            _DbContext = dbContext;
        }
        public async Task<Car> AddCar(Car car)
        {
            await _DbContext.Cars.AddAsync(car);
            _DbContext.SaveChanges();

            return car;
        }

        public async Task<List<Car>> GetCars(Filter filters)
        {
            var data = await _DbContext.Cars.ToListAsync();
            if (!string.IsNullOrEmpty(filters.CarName))
            {
                data = data.Where(x => x.CarName.ToLower().Contains(filters.CarName)).ToList();
            }
            if (!string.IsNullOrEmpty(filters.Brand))
            {
                data = data.Where(x => x.Brand.ToLower().Contains(filters.Brand)).ToList();
            }
            if (!string.IsNullOrEmpty(filters.Model))
            {
                data = data.Where(x => x.Model.ToLower().Contains(filters.Model)).ToList();
            }
            if (!string.IsNullOrEmpty(filters.Color))
            {
                data = data.Where(x => x.Color.ToLower().Contains(filters.Color)).ToList();
            }
            if (!string.IsNullOrEmpty(filters.Transmition))
            {
                data = data.Where(x => x.Transmition.ToLower().Contains(filters.Transmition)).ToList();
            }
            if (!string.IsNullOrEmpty(filters.FuelType))
            {
                data = data.Where(x => x.FuelType.ToLower().Contains(filters.FuelType)).ToList();
            }
            if (!string.IsNullOrEmpty(filters.SeatCapacity))
            {
                data = data.Where(x => x.SeatCapacity.ToLower().Contains(filters.SeatCapacity)).ToList();
            }

            if (filters.Price!=null &&  filters.Price>0)
            {
                data = data.Where(x => x.Price.Equals(filters.Price)).ToList();
            }
            return data;
        }
    }
}