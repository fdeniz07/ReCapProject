using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
             //CarManager carManager = new CarManager(new InMemoryCarDal());
           CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car { Id = 1, CarName = "BMW", BrandId = 1, ColorId = 1, ModelId = 2, ModelYear = 2022, DailyPrice = 60.0, Description = "Konforlu Yolculuk" });
            carManager.Add(new Car { Id = 2, CarName = "Audi", BrandId = 2, ColorId = 1, ModelId = 1, ModelYear = 2021, DailyPrice = 50.0, Description = "Saglamliga Güvenin" });
            carManager.Add(new Car { Id = 3, CarName = "Mercedes", BrandId = 3, ColorId = 2, ModelId = 4, ModelYear = 2022, DailyPrice = 65.0, Description = "Bir Alman Harikasi" });
            carManager.Add(new Car { Id = 4, CarName = "TOGG", BrandId = 4, ColorId = 4, ModelId = 1, ModelYear = 2023, DailyPrice = 40.0, Description = "Yerli ve Milli Gücümüz" });
            carManager.Add(new Car { Id = 5, CarName = "Renault", BrandId = 5, ColorId = 3, ModelId = 5, ModelYear = 2022, DailyPrice = 30.0, Description = "Fransiz Ati" });
            carManager.Add(new Car { Id = 6, CarName = "Ford", BrandId = 6, ColorId = 5, ModelId = 3, ModelYear = 2020, DailyPrice = 35.0, Description = "Yollarin Lordu" });


            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName + " - " + car.ModelYear + " - $" + car.DailyPrice + " - " + car.Description);
            }

            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.BrandId + " " + car.Description);
            }

            foreach (var car in carManager.GetCarsByColorId(5))
            {
                Console.WriteLine(car.ColorId + " " + car.Description);
            }
        }
    }
}
