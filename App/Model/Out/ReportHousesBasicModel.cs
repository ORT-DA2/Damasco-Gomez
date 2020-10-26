using System.Diagnostics.CodeAnalysis;
using Domain.Entities;

namespace Model.Out
{
    [ExcludeFromCodeCoverage]
    public class ReportHousesBasicModel
    {
        public string NameHouse {get; set;}
        public int CantBookings {get; set;}
        public ReportHousesBasicModel(Report report)
        {
            this.NameHouse = report.NameHouse;
            this.CantBookings = report.CantBookings;
        }
        public override bool Equals(object obj)
        {
            var result = false;
            if(obj is ReportHousesBasicModel report)
            {
                result = this.NameHouse == report.NameHouse ;
            }
            return result;
        }
    }
}