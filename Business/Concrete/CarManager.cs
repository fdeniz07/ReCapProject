using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CARS_LISTED);
        }

        public IResult Add(Car car)
        {
            if (car.CarName.Length > 1 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CAR_ADDED);
            }
            else
            {
                return new ErrorResult(
                    "Araç ismi en az iki karakter olmalı ve Günlük Kira bedeli 0'dan büyük olmalıdır!");
            }
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CAR_UPDATED);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CAR_DELETED);
        }

        public IDataResult<Car> GetById(int carId)
        {
            //Bu kisim mutlaka ilgili id bulunamadiginda HANDLE EDILMELI!!!
            //var results = _carDal.Get(c => c.Id == carId);

            //if (results == null)
            //{
            //    return new ErrorDataResult<Car>(String.Format(Messages.CAR_NOT_FOUND, carId));
            //}

            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId), String.Format(Messages.CAR_LISTED, carId));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            var results = _carDal.GetAll(c => c.BrandId == id);

            if (results.Count == 0)
            {
                return new ErrorDataResult<List<Car>>(String.Format(Messages.CAR_NOT_FOUND, id));
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            var results = _carDal.GetAll(c => c.ColorId == id);

            if (results.Count == 0)
            {
                return new ErrorDataResult<List<Car>>(String.Format(Messages.CAR_NOT_FOUND, id));
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetails());
        }
    }
}