using System;
using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Model.In
{
    public class HouseSearchModel
    {
        [FromQuery(Name="checkin")]
        public DateTime CheckIn {get; set;}
        [FromQuery(Name="checkout")]
        public DateTime CheckOut{get; set;}
        [FromQuery(Name="touristpointid")]
        public int TouristPointId {get ; set; }
        [FromQuery(Name="cantadults")]
        public int CantAdults {get; set;}
        [FromQuery(Name="cantchildrens")]
        public int CantChildrens {get; set;}
        [FromQuery(Name="cantbabys")]
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