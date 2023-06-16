using System.Collections.Generic;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        List<Car> FindAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car); 
        Car FindById(int categoryId);
    }
}
