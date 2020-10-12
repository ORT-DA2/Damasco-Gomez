using System;
using System.Diagnostics.CodeAnalysis;
using Domain;

namespace Model
{
    [ExcludeFromCodeCoverage]
    public class BookingBasicModel
    {
        public int Id {get; private set; }
        public string Name {get; private set;}
        public string Email {get; private set;}
        public string Code {get; private set;}
        public int HouseId {get; private set;}
        public int StateId {get; private set;}
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
            this.StateId = booking.StateId;
            this.Price = booking.Price;
            this.CheckIn = booking.CheckIn;
            this.CheckOut = booking.CheckOut;
        }
        public override bool Equals(object obj)
        {
            var result = false;
            if(obj is BookingBasicModel booking)
            {
                result = this.Id == booking.Id ;
            }
            return result;
        }
    }
}