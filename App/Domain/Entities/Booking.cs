using System;

namespace Domain
{
    public class Booking
    {
        public int Id {get; set; }

        public string Name {get; set;}

        public string Email {get; set;}

        public string Code {get; set;}

        public House House {get; set;}

        public string State {get; set;}

        public int Price {get; set;}

        public  DateTime CheckIn {get; set;}

        public DateTime CheckOut {get; set;}

        public override bool Equals(object obj)
        {
            var result = false;
            if(obj is Booking booking)
            {
                result = this.Id == booking.Id ;
            }
            return result;
        }

    }

}