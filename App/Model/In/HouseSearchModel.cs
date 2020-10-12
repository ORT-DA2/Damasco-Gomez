using System;
using System.Diagnostics.CodeAnalysis;
using Domain.Entities;

namespace Model.In
{
    [ExcludeFromCodeCoverage]
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
            if (dateString.Length != 10 && !dateString.Contains("/")) throw new ArgumentException("Date is not in the right format");
            string[] parse = dateString.Split('/');
            int year = int.Parse(parse[2]);
            int month = int.Parse(parse[1]);
            int day = int.Parse(parse[0]);
            DateTime date = new DateTime(year,month,day);
            return date;
        }
        public bool NotNull()
        {
            bool notNull;
            notNull = this.CheckIn != null || this.CheckOut!=null || this.TouristPointId > 0 ||
                this.CantAdults > 0 || this.CantBabys > 0 || this.CantChildrens > 0;
            return notNull;
        }
        public void CheckAllParameters()
        {
            bool allParams;
            allParams = this.CheckIn != null && this.CheckOut!=null && this.TouristPointId > 0;
            if (!allParams) throw new ArgumentException("You need to put dates and tourist point id at least");
        }

    }
}