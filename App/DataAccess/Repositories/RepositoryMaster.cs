using System;
using DataAccess.Context;
using DataAccessInterface.Repositories;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class RepositoryMaster : IDisposable
    {
        private DbContext context;
        private IRepository<Category> categories;
        private IRepository<Booking> bookings;
        private IRepository<House> houses;
        private IRepository<Person> persons;
        private IRepository<Region> regions;
        private IRepository<TouristPoint> touristPoints;
        private IRepository<SessionUser> sessions;
        private bool isDispose = false;
        public RepositoryMaster(DbContext masterContext)
        {
            this.context = masterContext;
        }
        public void Dispose()
        {
            this.context.Dispose();
        }
        public IRepository<Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    this.categories = new Repository<Category>(context);
                }
                return this.categories;
            }
        }
        public IRepository<Booking> Bookings
        {
            get
            {
                if (bookings == null)
                {
                    this.bookings = new Repository<Booking>(context);
                }
                return this.bookings;
            }
        }
        public IRepository<House> Houses
        {
            get
            {
                if (houses == null)
                {
                    this.houses = new Repository<House>(context);
                }
                return this.houses;
            }
        }
        public IRepository<Person> Persons
        {
            get
            {
                if (persons == null)
                {
                    this.persons = new Repository<Person>(context);
                }
                return this.persons;
            }
        }
        public IRepository<Region> Regions
        {
            get
            {
                if (regions == null)
                {
                    this.regions = new Repository<Region>(context);
                }
                return this.regions;
            }
        }
        public IRepository<TouristPoint> TouristPoints
        {
            get
            {
                if (touristPoints == null)
                {
                    this.touristPoints = new Repository<TouristPoint>(context);
                }
                return this.touristPoints;
            }
        }
        public  IRepository<SessionUser> Sessions
        {
            get
            {
                if (sessions == null)
                {
                    this.sessions = new Repository<SessionUser>(context);
                }
                return this.sessions;
            }
        }
    }
}