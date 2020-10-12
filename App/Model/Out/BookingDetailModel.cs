using System;
using System.Diagnostics.CodeAnalysis;
using Domain;
using Domain.Entities;
using Model.Out;

namespace Model
{
    [ExcludeFromCodeCoverage]
    public class BookingDetailModel
    {

        public int Id {get; private set; }
        public string Name {get; private set;}
        public string Email {get; private set;}
        public string Code {get; private set;}
        public int HouseId {get; private set;}
        public HouseBasicModel House {get; private set;}
        public StateBasicModel State {get; private set;}
        public int StateId {get; private set;}
        public int Price {get; private set;}
        public  DateTime CheckIn {get; private set;}
        public DateTime CheckOut {get; private set;}
        public BookingDetailModel(Booking booking)
        {
            this.Id = booking.Id;
            this.Name = booking.Name;
            this.Email = booking.Email;
            this.Code = booking.Code;
            this.HouseId = booking.HouseId;
            this.House = new HouseBasicModel(booking.House);
            this.StateId = booking.StateId;
            this.State = new StateBasicModel(booking.State);
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