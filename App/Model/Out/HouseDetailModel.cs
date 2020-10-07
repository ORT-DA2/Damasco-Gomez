using System;
using Domain;

namespace Model
{
    public class HouseDetailModel
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

        public override bool Equals(object obj)
        {
            var result = false;
            if(obj is HouseDetailModel house)
            {
                result = this.Id == house.Id ;
            }
            return result;
        }
    }
}