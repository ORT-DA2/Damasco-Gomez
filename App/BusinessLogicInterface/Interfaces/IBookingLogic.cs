using System.Collections.Generic;
using BusinessLogicInterface.Interfaces;
using Domain;
using Model;

namespace BusinessLogicInterface
{
    public interface IBookingLogic
    {
        IEnumerable<Booking> GetAll();
        Booking GetBy(int id);
        Booking Add(Booking element);
        Booking Update(int id, Booking element);
        void Delete(int id);
        void Delete();
        bool Exist(Booking element);
    }
}