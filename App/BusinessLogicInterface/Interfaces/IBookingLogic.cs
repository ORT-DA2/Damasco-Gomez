using System.Collections.Generic;
using Domain;

namespace BusinessLogicInterface
{
    public interface IBookingLogic
    {
        IEnumerable<Booking> GetAll();
        Booking GetBy(int id);
        void Add(Booking category);
        void Update(Booking category);
        void Delete(int id);
        void Delete();
        bool Exist(Booking category);
    }
}