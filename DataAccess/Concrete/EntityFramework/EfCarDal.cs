using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, MsDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarsDetails()
        {
            using (MsDbContext context = new MsDbContext())
            {
                var result = from car in context.Cars
                    join b in context.Brands
                        on car.BrandId equals b.Id
                    join col in context.Colors
                        on car.ColorId equals col.Id
                    join m in context.Models
                        on car.ModelId equals m.Id
                    select new CarDetailDto
                    {
                        CarName = car.CarName,
                        BrandName = b.BrandName,
                        ColorName = col.ColorName,
                        ModelYear = car.ModelYear,
                        ModelName = m.ModelName,
                        DailyPrice = car.DailyPrice,
                        Description = car.Description
                    };
                return result.ToList();
            }
        }
    }
}