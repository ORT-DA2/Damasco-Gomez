using System;

namespace Domain
{
    public class Booking
    {
        public Guid Id {get; set; }

        public string Name {get; set;}

        public string Email {get; set;}

        public string Code {get; set;}

        public House House {get; set;}

        public string State {get; set;}

        public string Price {get; set;}

        public  DateTime CheckIn {get; set;}

        public DateTime CheckOut {get; set;}

        public void UpdateState (string state)
        {

        }
        public void UpdateDates(DateTime chechkIn, DateTime checkOut)
        {


        }
        public void UpdatePrice(int price)
        {

        }
        public void UpadteContact (string email)
        {

        }

    }

}