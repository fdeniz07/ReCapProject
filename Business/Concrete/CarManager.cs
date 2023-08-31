using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using Business.ValidationRules.FluentValidation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CARS_LISTED);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            #region Attribute Öncesi Kod Yapisi
            //var context = new ValidationContext<Car>(car);
            //CarValidator carValidator = new CarValidator();

            //var result = carValidator.Validate(context);
            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //}

            #region Kötü kodun iyilestirilip, CrossCuttingConcerns olarak ele alinmasi
            //if (car.CarName.Length < 1 && car.DailyPrice <= 0)
            //{
            //    return new ErrorResult(
            //        "Araç ismi en az iki karakter olmalı ve Günlük Kira bedeli 0'dan büyük olmalıdır!");

            //}
            #endregion
            #endregion
            _carDal.Add(car);
            return new SuccessResult(Messages.CAR_ADDED);
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
            var results = _carDal.Get(c => c.Id == carId);

            if (results == null)
            {
                return new ErrorDataResult<Car>(string.Format(Messages.CAR_NOT_FOUND, carId));
            }

            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId),
                String.Format(Messages.CAR_LISTED_WITH_ID, carId));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            var results = _carDal.GetAll(c => c.BrandId == id);

            if (results.Count == 0)
            {
                return new ErrorDataResult<List<Car>>(Messages.CARS_NOT_FOUND);
            }

            if (results.Count < 2)
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id), Messages.CAR_LISTED);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id), Messages.CARS_LISTED);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            var results = _carDal.GetAll(c => c.ColorId == id);

            if (results.Count == 0)
            {
                return new ErrorDataResult<List<Car>>(Messages.CARS_NOT_FOUND);
            }

            if (results.Count < 2)
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id), Messages.CAR_LISTED);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id), Messages.CARS_LISTED);
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetails()
        {
            var results = _carDal.GetAll();

            if (results == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>(string.Format(Messages.CARS_NOT_FOUND));
            }

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetails(),
                Messages.CARS_LISTED);
        }
    }
}