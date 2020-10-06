using System;
using Domain;

namespace Model
{
    public class BookingBasicModel
    {
        public int Id {get; set; }
        public string Name {get; set;}
        public string Email {get; set;}
        public string Code {get; set;}
        public int HouseId {get; set;}
        public string State {get; set;}
        public int Price {get; set;}
        public  DateTime CheckIn {get; set;}
        public DateTime CheckOut {get; set;}
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