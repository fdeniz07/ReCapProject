using Business.Abstract;
using Business.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<ICarService, CarManager>();
            services.AddScoped<ICustomerService, CustomerManager>();
            services.AddScoped<IRentalService, RentalManager>();
            services.AddScoped<IUserService, UserManager>();
        }
    }
}