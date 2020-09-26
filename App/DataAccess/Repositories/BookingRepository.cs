using DataAccessInterface.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class BookingRepository : AccessData<Booking> , IBookingRepository
    {
        IRepository<House> repositoryHouse ;
        public BookingRepository(RepositoryMaster repositoryMaster)
        {
            this.repository = repositoryMaster.Bookings;
            this.repositoryHouse = repositoryMaster.Houses;
        }

        protected override void Validate(Booking element)
        {
            throw new System.NotImplementedException();
        }
    }
}