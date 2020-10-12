using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Domain
{
    public class Booking
    {
        public int Id {get; set; }

        public string Name {get; set;}

        public string Email {get; set;}

        public string Code {get; set;}

        public int HouseId {get; set;}
        public virtual House House {get; set;}

        public string State {get; set;}

        public int Price {get; set;}

        public  DateTime CheckIn {get; set;}

        public DateTime CheckOut {get; set;}
        [ExcludeFromCodeCoverage]
        public override bool Equals(object obj)
        {
            var result = false;
            if(obj is Booking booking)
            {
                result = this.Id == booking.Id ;
            }
            return result;
        }

        public void Update(Booking element)
        {
            if(element.Name != null) this.Name = element.Name;
            if(element.Email != null) this.Email = element.Email;
            if(element.State != null) this.State = element.State;
            if(element.Price>0) this.Price = element.Price;
            if(element.HouseId>0) this.HouseId = element.HouseId;
            if(element.CheckIn != null) this.CheckIn = element.CheckIn;
            if(element.CheckOut != null) this.CheckOut = element.CheckOut;
        }
        private static Random random = new Random();
        public static string RandomString()
        {
            int length = 10;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringCode = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return stringCode;
        }
        public bool IsEmpty()
        {
            bool nameNull = Name == null;
            bool emailNull = Email == null;
            bool houseIdZero = HouseId == 0;
            bool priceZero = Price == 0;
            bool checkInEmpty = CheckIn == DateTime.MinValue;
            bool checkOutEmpty = CheckOut == DateTime.MinValue;
            return nameNull || emailNull || houseIdZero || priceZero || checkInEmpty || checkOutEmpty ;
        }
    }

}