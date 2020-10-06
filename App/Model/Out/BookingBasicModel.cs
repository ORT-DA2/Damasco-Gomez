using System;
using Domain;

namespace Model
{
    public class BookingBasicModel
    {
        public int Id {get; private set; }
        public string Name {get; private set;}
        public string Email {get; private set;}
        public string Code {get; private set;}
        public int HouseId {get; private set;}
        public string State {get; private set;}
        public int Price {get; private set;}
        public  DateTime CheckIn {get; private set;}
        public DateTime CheckOut {get; private set;}
        public BookingBasicModel(Booking booking)
        {
            this.Id = booking.Id;
            this.Name = booking.Name;
            this.Email = booking.Email;
            this.Code = booking.Code;
            this.HouseId = booking.HouseId;
            this.State = booking.State;
            this.Price = booking.Price;
            this.CheckIn = booking.CheckIn;
            this.CheckOut = booking.CheckOut;
        }
    }
}