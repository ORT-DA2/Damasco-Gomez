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

        public string Price {get; set;}

        public  DateTime CheckIn {get; set;}

        public DateTime CheckOut {get; set;}

        public void UpdateInformation()
        {

        }

    }

}