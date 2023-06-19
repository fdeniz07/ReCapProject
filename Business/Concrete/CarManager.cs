using System;
using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        #region Implementation of ICarService

        public List<Car> GetAll()
        {
            return _carDal.FindAll();
        }

        public void Add(Car car)
        {
            if (car.CarName.Length > 1 && car.DailyPrice > 0)

                _carDal.Add(car);
            else
                Console.WriteLine("Araç ismi en az iki karakter olmalı ve Günlük Kira bedeli 0'dan büyük olmalıdır!");
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public Car GetById(int categoryId)
        {
            return _carDal.Find(c => c.Id == categoryId);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.FindAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.FindAll(c => c.ColorId == id);
        }

        #endregion
    }
}
