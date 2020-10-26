using System;
using System.Diagnostics.CodeAnalysis;
using Domain.Entities;

namespace Model.In
{
    [ExcludeFromCodeCoverage]
    public class ReportTouristPointModel
    {
        public int idTp  {get; set;}
        public string dateFrom  {get; set;}
        public string dateOut  {get; set;} 
        public ReportTouristPoint ToEntity()
        {
            return new ReportTouristPoint()
            {
                idTp= this.idTp,
                dateFrom = this.dateFrom,
                dateOut= this.dateOut,

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
            notNull = this.dateFrom != null || this.dateOut!=null;
            return notNull;
        }
        public void CheckAllParameters()
        {
            bool allParams;
            allParams = this.dateFrom != null && this.dateOut!=null && this.idTp > 0;
            if (!allParams) throw new ArgumentException("You need to put dates and tourist point );
        }

    }
}