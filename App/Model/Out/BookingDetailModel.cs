using Domain;

namespace Model
{
    public class BookingDetailModel
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
    }
}