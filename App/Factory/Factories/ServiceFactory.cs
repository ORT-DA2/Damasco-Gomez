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
            services.AddScoped<IHouseRepository, HouseRepository>();
            services.AddScoped<IHouseLogic, HouseLogic>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonLogic, PersonLogic>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<IRegionLogic, RegionLogic>();
            services.AddScoped<IBookingLogic, BookingLogic>();
            services.AddScoped<ICategoryLogic, CategoryLogic>();
            services.AddScoped<IHouseLogic, HouseLogic>();
            services.AddScoped<IPersonLogic, PersonLogic>();
            services.AddScoped<ITouristPointLogic, TouristPointLogic>();
            
        }
        public void AddDbContextService()
        {
            services.AddDbContext<DbContext, VidlyContext>();
        }
    }
}