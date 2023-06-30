using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var carManager = CarsLoader(); //For InMemory Testing

            CarManager carManager = new CarManager(new EfCarDal());

            // GetAllCars(carManager);

            // GetCarsByBrandId(carManager, 1);

            // GetCarsByColorId(carManager, 5);

            GetAllCarDetails(carManager);
        }

        private static void GetAllCarDetails(CarManager carManager)
        {
            Console.WriteLine("****************************** Car List Details *******************************\n");

            Console.WriteLine("{0,10} {1,12} {2,8} {3,10} {4,6} {5,7} {6,15}\n", "Car Name", "Brand Name", "Color",
                "Model Year", "Model Name", "Daily Price($)", "Description");
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("{0,10} {1,12} {2,8} {3,10} {4,6} {5,7} {6,25}", car.CarName, car.BrandName,
                    car.ColorName, car.ModelYear, car.ModelName, car.DailyPrice, car.Description);
            }
        }


        private static void GetCarsByColorId(CarManager carManager, int colorId)
        {
            Console.WriteLine("****************************** Car List By Color Id *******************************\n");

            Console.WriteLine("{0,5} {1,10} {2,25}", "Color", "Car Name", "Description");
            foreach (var car in carManager.GetCarsByColorId(colorId))
            {
                Console.WriteLine("{0,5} {1,10} {2,25}", car.ColorId, car.CarName, car.Description);
            }
        }

        private static void GetCarsByBrandId(CarManager carManager, int brandId)
        {
            Console.WriteLine("******************************** Car List By Brand Id ******************************\n");

            Console.WriteLine("{0,5} {1,10} {2,25}", "Brand", "Car Name", "Description");
            foreach (var car in carManager.GetCarsByBrandId(brandId))
            {
                Console.WriteLine("{0,5} {1,10} {2,25}", car.BrandId, car.CarName, car.Description);
            }
        }

        private static void GetAllCars(CarManager carManager)
        {
            Console.WriteLine(
                "********************************* Car List By Brand Id *******************************\n");

            Console.WriteLine("{0,5} {1,12} {2,20} {3,13} {4,25}", "Id", "Car Name", "Daily Price($)", "Model Year",
                "Description");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0,5} {1,12} {2,10} {3,20} {4,30}", car.BrandId, car.CarName, car.DailyPrice,
                    car.ModelYear, car.Description);
            }
        }

        private static CarManager CarsLoader()
        {
            //CarManager carManager = new CarManager(new InMemoryCarDal());
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car
            {
                Id = 1,
                CarName = "BMW",
                BrandId = 1,
                ColorId = 1,
                ModelId = 2,
                ModelYear = 2022,
                DailyPrice = 60.0,
                Description = "Konforlu Yolculuk"
            });
            carManager.Add(new Car
            {
                Id = 2,
                CarName = "Audi",
                BrandId = 2,
                ColorId = 1,
                ModelId = 1,
                ModelYear = 2021,
                DailyPrice = 50.0,
                Description = "Saglamliga Güvenin"
            });
            carManager.Add(new Car
            {
                Id = 3,
                CarName = "Mercedes",
                BrandId = 3,
                ColorId = 2,
                ModelId = 4,
                ModelYear = 2022,
                DailyPrice = 65.0,
                Description = "Bir Alman Harikasi"
            });
            carManager.Add(new Car
            {
                Id = 4,
                CarName = "TOGG",
                BrandId = 4,
                ColorId = 4,
                ModelId = 1,
                ModelYear = 2023,
                DailyPrice = 40.0,
                Description = "Yerli ve Milli Gücümüz"
            });
            carManager.Add(new Car
            {
                Id = 5,
                CarName = "Renault",
                BrandId = 5,
                ColorId = 3,
                ModelId = 5,
                ModelYear = 2022,
                DailyPrice = 30.0,
                Description = "Fransiz Ati"
            });
            carManager.Add(new Car
            {
                Id = 6,
                CarName = "Ford",
                BrandId = 6,
                ColorId = 5,
                ModelId = 3,
                ModelYear = 2020,
                DailyPrice = 35.0,
                Description = "Yollarin Lordu"
            });
            return carManager;
        }
    }
}