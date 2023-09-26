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

        public async Task<List<Car>> GetCars(string filters)
        {
            var data = _DbContext.Cars.AsQueryable();

            data = data.Where(x => x.CarName.ToLower().Contains(filters.ToLower()));

            data = data.Where(x => x.Brand.ToLower().Contains(filters.ToLower()));

            data = data.Where(x => x.Model.ToLower().Contains(filters.ToLower()));

            data = data.Where(x => x.Transmition.ToLower().Contains(filters.ToLower()));

            data = data.Where(x => x.FuelType.ToLower().Contains(filters.ToLower()));

            data = data.Where(x => x.SeatCapacity.ToLower().Contains(filters.ToLower()));

            data = data.Where(x => x.Price.Equals(filters));

            return await data.ToListAsync();
        }
    }
}