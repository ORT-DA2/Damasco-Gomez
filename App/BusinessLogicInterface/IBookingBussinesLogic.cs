namespace BusinessLogicInterface
{
    public interface IBookingBussinesLogic
    {
        void GetBookingById(int id);

        void GetBookingByName(in string name);

        void CreateBooking(in int checkIn, in int checkOut, in string name, in string email, in string house, in string token);

        void GetCode(in int id, in string token);

        void DeleteBooking(in int id, in string token);
    }
}