using System;
using Domain;

namespace Model
{
    public class BookingModel
    {
        public string Name {get; set;}
        public string Email {get; set;}
        public int HouseId {get; set;}
        public int StateId {get; set;}
        public int Price {get; set;}
        public  DateTime CheckIn {get; set;}
        public DateTime CheckOut {get; set;}
        public Booking ToEntity(bool post = true)
        {
            Booking booking = new Booking()
            {
                Name = this.Name,
                Email = this.Email,
                HouseId = this.HouseId,
                Price = this.Price,
                CheckIn = this.CheckIn,
                CheckOut = this.CheckOut
            };
            booking.Code = Booking.RandomString();
            if(post) booking.StateId = 1;
            else booking.StateId = this.StateId;
            if(post && booking.IsEmpty()) throw new ArgumentException("No values");
            return booking;
        }
    }
}