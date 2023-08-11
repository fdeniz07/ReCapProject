
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Core.Utilities.Results;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<CarImage> GetByImageId(int imageId);
        IDataResult<List<CarImage>> GetByCarId(int carId);
        IDataResult<List<CarImage>> GetAll();

        IResult Add(IFormFile file, CarImage carImage);
        IResult Update(IFormFile file, CarImage carImage);
        IResult Delete(CarImage carImage);
    }
}
