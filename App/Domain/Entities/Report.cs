using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    [ExcludeFromCodeCoverage]  
    public class Report
    {
        public string NameHouse {get; set; }
        public  int CantBookings {get; set; }
    }
}