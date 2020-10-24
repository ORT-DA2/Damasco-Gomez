using System;
using System.Diagnostics.CodeAnalysis;
using Domain.Entities;

namespace Model.In
{
    [ExcludeFromCodeCoverage]
    public class BookingReportModel
    {
        public int IdTp {get; set;}
        public  string DateFrom {get; set;}
        public string DateTo {get; set;}

        public BookingReport ToEntity()
        {
            return new BookingReport()
            {
                DateFrom = ParseDateTime(this.DateFrom),
                DateTo = ParseDateTime(this.DateTo),
                IdTp = this.IdTp,
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
            notNull = this.DateFrom != null || this.DateTo!=null || this.IdTp > 0 ;
            return notNull;
        }
        public void CheckAllParameters()
        {
            bool allParams;
            allParams = this.DateFrom != null && this.DateTo!=null && this.IdTp > 0;
            if (!allParams) throw new ArgumentException("Put dates and tourist point");
        }

    }
}