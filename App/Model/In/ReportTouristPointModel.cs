using System.Diagnostics.CodeAnalysis;
using Domain.Entities;

namespace Model.In
{
    [ExcludeFromCodeCoverage]
    public class ReportTouristPointModel
    {
        public int idTp  {get; set;}
        public string dateFrom  {get; set;}
        public string dateOn  {get; set;} 
         public ReportTouristPoint ToEntity()
        {
            return new ReportTouristPoint()
            {
                idTp= this.idTp,
                dateFrom = this.dateFrom,
                dateOn= this.dateOn,

            };
        }
    }
}