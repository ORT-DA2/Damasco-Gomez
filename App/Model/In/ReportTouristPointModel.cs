using System;
using System.Diagnostics.CodeAnalysis;
using Domain.Entities;

namespace Model.In
{
    [ExcludeFromCodeCoverage]
    public class ReportTouristPointModel
    {
        public int IdTouristPoint  {get; set;}
        public string DateFrom  {get; set;}
        public string DateOut  {get; set;} 
        public ReportTouristPoint ToEntity()
        {
            return new ReportTouristPoint()
            {
                IdTouristPoint= this.IdTouristPoint,
                DateFrom = ParseDateTime(this.DateFrom),
                DateOut= ParseDateTime(this.DateOut),

            };
        }
        public DateTime ParseDateTime(string dateString)
        {
            if (dateString.Length != 10 && !dateString.Contains("/")) throw new ArgumentException("Date is not in the right format");
            string[] parse = dateString.Split('/');
            int year = int.Parse(parse[2]);
            int month = int.Parse(parse[0]);
            int day = int.Parse(parse[1]);
            DateTime date = new DateTime(year,month,day);
            return date;
        }
        public bool NotNull()
        {
            bool notNull;
            notNull = this.DateFrom != null || this.DateOut!=null ||  this.IdTouristPoint >0;
            return notNull;
        }
        public void CheckAllParameters()
        {
            bool allParams;
            allParams = this.DateFrom != null && this.DateOut!=null && this.IdTouristPoint > 0;
            if (!allParams) throw new ArgumentException("You need to put dates and tourist point ");
        }

    }
}