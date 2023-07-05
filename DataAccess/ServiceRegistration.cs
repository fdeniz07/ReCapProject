using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddScoped<IBrandDal, EfBrandDal>();
            services.AddScoped<ICarDal, EfCarDal>();
            services.AddScoped<IColorDal, EfColorDal>();
            services.AddScoped<ICustomerDal, EfCustomerDal>();
            services.AddScoped<IModelDal, EfModelDal>();
            services.AddScoped<IRentalDal, EfRentalDal>();
            services.AddScoped<IUserDal, EfUserDal>();
        }
    }
}