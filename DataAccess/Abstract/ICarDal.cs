using System.Collections.Generic;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        //List<Car> FindAll();
        //void Add(Car car);
        //void Update(Car car);
        //void Delete(Car car); 
        //Car FindById(int categoryId);
        List<CarDetailDto> GetCarsDetails();
    }
}
