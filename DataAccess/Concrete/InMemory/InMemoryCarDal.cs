using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,CarName = "BMW",BrandId = 1,ColorId = 1,ModelId = 2,ModelYear = 2022,DailyPrice = 60.0,Description = "Konforlu Yolculuk"},
                new Car{Id=2,CarName = "Audi",BrandId = 2,ColorId = 1,ModelId = 1,ModelYear = 2021,DailyPrice = 50.0,Description = "Saglamliga Güvenin"},
                new Car{Id=3,CarName = "Mercedes",BrandId = 3,ColorId = 2,ModelId = 4,ModelYear = 2022,DailyPrice = 65.0,Description = "Bir Alman Harikasi"},
                new Car{Id=4,CarName = "TOGG",BrandId = 4,ColorId = 4,ModelId = 1,ModelYear = 2023,DailyPrice = 40.0,Description = "Yerli ve Milli Gücümüz"},
                new Car{Id=5,CarName = "Renault",BrandId = 5,ColorId = 3,ModelId = 5,ModelYear = 2022,DailyPrice = 30.0,Description = "Fransiz Ati"},
                new Car{Id=6,CarName = "Ford",BrandId = 6,ColorId = 5,ModelId = 3,ModelYear = 2020,DailyPrice = 35.0,Description = "Yollarin Lordu"}
            };
        }


        #region Implementation of ICarDal

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car updatedCar = _cars.SingleOrDefault(c => c.Id == car.Id);
            if (updatedCar != null)
            {
                updatedCar.CarName = car.CarName;
                updatedCar.BrandId = car.BrandId;
                updatedCar.ColorId = car.ColorId;
                updatedCar.ModelId = car.ModelId;
                updatedCar.ModelYear = car.ModelYear;
                updatedCar.DailyPrice = car.DailyPrice;
                updatedCar.Description = car.Description;
            }

            throw new Exception("Ilgili Id ye ait arac bulunamadi");
        }

        public void Delete(Car car)
        {
            Car deletedCar = _cars.SingleOrDefault(c => c.Id == car.Id);
            if (deletedCar!=null)
            {
                _cars.Remove(deletedCar);
            }
            throw new Exception("Ilgili Id ye ait arac bulunamadi");
        }

        public Car GetById(int categoryId)
        {
            return _cars.Find(c => c.Id == categoryId);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            var cars = _cars.ToList();
            return cars;
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            var car = _cars.SingleOrDefault();
            return car;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
