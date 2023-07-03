using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<Rental> GetById(int id);

        IDataResult<List<Rental>> GetAll();

        IDataResult<List<Rental>> GetAllByCarId(int carId);

        IResult Add(Rental rental);

        IResult Update(Rental rental);

        IResult Delete(int rentalId);

        IResult CheckReturnDateByCarId(int carId);

        IResult IsRentable(Rental rental);
    }
}
