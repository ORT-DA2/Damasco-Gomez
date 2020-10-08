using System;
using Domain;
using Domain.Entities;

namespace Model.In
{
    public class HouseSearchModel
    {
        public string CheckIn {get; set;}
        public string CheckOut{get; set;}
        public int TouristPointId {get ; set; }
        public int CantAdults {get; set;}
        public int CantChildrens {get; set;}
        public int CantBabys {get; set;}
        public HouseSearch ToEntity()
        {
            return new HouseSearch()
            {
                CheckIn = ParseDateTime(this.CheckIn),
                CheckOut = ParseDateTime(this.CheckOut),
                TouristPointId = this.TouristPointId,
                CantAdults = this.CantAdults,
                CantChildrens = this.CantChildrens,
                CantBabys = this.CantBabys
            };
        }

        public DateTime ParseDateTime(string dateString)
        {
            string[] parse = dateString.Split('/');
            if (parse.Length != 3 && !dateString.Contains("/")) throw new ArgumentException("Date is not in the right format");
            int year = int.Parse(parse[2]);
            int month = int.Parse(parse[1]);
            int day = int.Parse(parse[0]);
            DateTime date = new DateTime(year,month,day);
            return date;
        }

    }
}