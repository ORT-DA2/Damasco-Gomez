using System;
using System.Collections.Generic;
using DataAccessInterface.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class BookingRepository: AccessData<Booking> , IBookingRepository
    {
        public BookingRepository(RepositoryMaster repositoryMaster)
        {
            this.repository = repositoryMaster.Bookings;
        }

        protected override void Validate(Booking element)
        {
            throw new NotImplementedException();
        }
    }
}