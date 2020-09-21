using BusinessLogic;
using BusinessLogic.Logics;
using BusinessLogicInterface;
using DataAccess.Context;
using DataAccess.Repositories;
using DataAccessInterface.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Factory.Factories
{
    public class ServiceFactory
    {
        private readonly IServiceCollection services;
        public ServiceFactory(IServiceCollection services)
        {
            this.services = services;
        }
        public void AddCustomServices()
        {
            services.AddScoped<ITouristPointRepository, TouristPointRepository>();
            services.AddScoped<ITouristPointLogic, TouristPointLogic>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IBookingLogic, BookingLogic>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryLogic, CategoryLogic>();
        }
        public void AddDbContextService()
        {
            services.AddDbContext<DbContext, VidlyContext>();
        }
    }
}