using System;
using Domain;

namespace Model
{
    public class BookingModel
    {
        public string Name {get; set;}
        public string Email {get; set;}
        public string Code {get; set;}
        public int HouseId {get; set;}
        public string State {get; set;}
        public int Price {get; set;}
        public  DateTime CheckIn {get; set;}
        public DateTime CheckOut {get; set;}
        public Booking ToEntity()
        {
            return new Booking()
            {
                Name = this.Name,
                Email = this.Email,
                Code = this.Code,
                HouseId = this.HouseId,
                State = this.State,
                Price = this.Price,
                CheckIn = this.CheckIn,
                CheckOut = this.CheckOut
            };
        }
    }
}