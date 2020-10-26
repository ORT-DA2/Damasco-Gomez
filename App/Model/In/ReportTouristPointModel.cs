using System.Diagnostics.CodeAnalysis;

namespace Model.In
{
    [ExcludeFromCodeCoverage]
    public class ReportTouristPointModel
    {
        int idTp  {get; set;}
        string dateFrom  {get; set;}
        string dateOn  {get; set;} 
         public ReportTouristPoint ToEntity()
        {
            return new ReportTouristPoint()
            {
                Name= this.Name,
                // TouristPoints = this.TouristPoints.Select(m => new TouristPoint()
                // {
                //     Id = m
                // }).ToList()
            };
        }
    }
}