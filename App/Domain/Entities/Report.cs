using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    [ExcludeFromCodeCoverage]  
    public class Report
    {
        public string NameHouse {get; set; }
        public  int CantBookings {get; set; }

        [ExcludeFromCodeCoverage]
        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is Report report)
            {
                result = this.NameHouse == report.NameHouse ;
            }
            return result;
        }
    }
}