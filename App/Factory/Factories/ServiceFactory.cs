using BusinessLogic;
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
            // services.AddScoped<ITouristPointRepository, TouristPointRepository>();
            services.AddScoped<ITouristPointLogic, TouristPointLogic>();
        }
        public void AddDbContextService()
        {
            services.AddDbContext<DbContext, VidlyContext>();
        }
    }
}