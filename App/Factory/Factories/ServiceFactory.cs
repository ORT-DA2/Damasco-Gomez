using System.Diagnostics.CodeAnalysis;
using BusinessLogic;
using BusinessLogic.Logics;
using BusinessLogicInterface;
using BusinessLogicInterface.Interfaces;
using Contracts;
using DataAccess.Context;
using DataAccess.Repositories;
using DataAccessInterface.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Factory.Factories
{
    [ExcludeFromCodeCoverage]
    public class ServiceFactory
    {
        private readonly IServiceCollection services;
        public ServiceFactory(IServiceCollection services)
        {
            this.services = services;
        }
        public void AddCustomServices()
        {
            services.AddScoped<RepositoryMaster>();
            services.AddScoped<ITouristPointRepository, TouristPointRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IHouseRepository, HouseRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<ISessionUserRepository, SessionUserRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<IImageHouseRepository, ImageHouseRepository>();
            services.AddScoped<IImageTouristPointRepository, ImageTouristPointRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<ITouristPointLogic, TouristPointLogic>();
            services.AddScoped<IBookingLogic, BookingLogic>();
            services.AddScoped<ICategoryLogic, CategoryLogic>();
            services.AddScoped<IHouseLogic, HouseLogic>();
            services.AddScoped<IPersonLogic, PersonLogic>();
            services.AddScoped<IRegionLogic, RegionLogic>();
            services.AddScoped<ISessionLogic, SessionLogic>();
            services.AddScoped<IReportLogic, ReportLogic>();
            services.AddScoped<IReviewLogic, ReviewLogic>();
            services.AddScoped<IReportLogic, ReportLogic>();

        }
        public void AddDbContextService()
        {
            services.AddDbContext<DbContext, VidlyContext>();
        }
    }
}