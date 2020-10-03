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

        public static void Update(Booking elementToUpdate, Booking element)
        {
            if(!element.Name.Equals("")) elementToUpdate.Name = element.Name;
            if(!element.Email.Equals("")) elementToUpdate.Email = element.Email;
            if(!element.State.Equals("")) elementToUpdate.State = element.State;
            if(element.Price>0) elementToUpdate.Price = element.Price;
            if(!element.CheckIn.Equals(DateTime.MinValue)) elementToUpdate.CheckIn = element.CheckIn;
            if(!element.CheckOut.Equals(DateTime.MinValue)) elementToUpdate.CheckOut = element.CheckOut;
        }
    }

}