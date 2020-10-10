using System;
using System.Diagnostics.CodeAnalysis;
using Domain;

namespace Model
{
    public class BookingDetailModel
    {

        [ExcludeFromCodeCoverageAttribute]
        public int Id {get; private set; }
        [ExcludeFromCodeCoverageAttribute]
        public string Name {get; private set;}
        [ExcludeFromCodeCoverageAttribute]
        public string Email {get; private set;}
        [ExcludeFromCodeCoverageAttribute]
        public string Code {get; private set;}
        [ExcludeFromCodeCoverageAttribute]
        public int HouseId {get; private set;}
        [ExcludeFromCodeCoverageAttribute]
        public HouseBasicModel House {get; private set;}
        [ExcludeFromCodeCoverageAttribute]
        public string State {get; private set;}
        [ExcludeFromCodeCoverageAttribute]
        public int Price {get; private set;}
        [ExcludeFromCodeCoverageAttribute]
        public  DateTime CheckIn {get; private set;}
        [ExcludeFromCodeCoverageAttribute]
        public DateTime CheckOut {get; private set;}
        public BookingDetailModel(Booking booking)
        {
            this.Id = booking.Id;
            this.Name = booking.Name;
            this.Email = booking.Email;
            this.Code = booking.Code;
            this.HouseId = booking.HouseId;
            this.House = new HouseBasicModel(booking.House);
            this.State = booking.State;
            this.Price = booking.Price;
            this.CheckIn = booking.CheckIn;
            this.CheckOut = booking.CheckOut;
        }
        public override bool Equals(object obj)
        {
            var result = false;
            if(obj is BookingDetailModel booking)
            {
                result = this.Id == booking.Id ;
            }
            return result;
        }
    }
}