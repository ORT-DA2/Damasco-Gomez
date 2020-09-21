using BusinessLogic;
using BusinessLogicInterface;
using DataAccess.Context;
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
        // public void AddCustomServices()
        // {
        //     services.AddScoped<ITouristPointRepository, TouristPointRepository>();
        //     services.AddScoped<IMovieLogic, MovieLogic>();
        // }
        public void AddDbContextService()
        {
            services.AddDbContext<DbContext, VidlyContext>();
        }
    }
}