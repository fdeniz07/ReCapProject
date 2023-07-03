using System;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using Business.Constants;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var result = this.IsRentable(rental);
            if (result != null)
                _rentalDal.Add(rental);
            return new SuccessResult(Messages.RENTAL_ADDEED);
        }

        public IResult CheckReturnDateByCarId(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate == null);
            if (result.Count > 0)
            {
                return new ErrorResult(String.Format(Messages.RENTAL_UNDELIVERED_CAR, carId));
            }

            return new SuccessResult(Messages.CAR_LISTED);
        }

        public IResult Delete(int rentalId)
        {
            var result = _rentalDal.GetAny(r => r.Id == rentalId);
            if (result)
            {
                var rental = _rentalDal.Get(r => r.Id == rentalId);
                rental.IsDeleted = true;
                rental.IsActive = false;
                rental.ModifiedDate = DateTime.Now;
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.RENTAL_ADDEED);
            }

            return new ErrorResult(String.Format(Messages.RENTAL_NOT_FOUND, rentalId));
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RENTALS_LISTED);
        }

        public IDataResult<List<Rental>> GetAllByCarId(int carId)
        {
            _rentalDal.Get(r => r.CarId == carId);
            return new SuccessDataResult<List<Rental>>(String.Format(Messages.CAR_LISTED, carId));
        }

        public IDataResult<Rental> GetById(int id)
        {
            _rentalDal.Get(r => r.Id == id);
            return new SuccessDataResult<Rental>(String.Format(Messages.RENTAL_LISTED, id));
        }

        public IResult IsRentable(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId);

            if (result.Any(r => r.RentEndDate >= rental.RentStartDate && r.RentStartDate <= rental.RentEndDate))
            {
                return new ErrorResult(Messages.RENTAL_NOT_AVAILABLE);
            }

            return new SuccessResult(Messages.RENTAL_AVAILABLE);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RENTAL_ADDEED);
        }
    }
}