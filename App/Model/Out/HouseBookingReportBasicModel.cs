using System.Diagnostics.CodeAnalysis;
using Domain;
using Domain.Entities;

namespace Model.Out
{
    [ExcludeFromCodeCoverage]
    public class HouseBookingReportBasicModel
    {
        public string HouseName {get ; set; }
        public int cantBooking {get ; set; }

         public override bool Equals(object obj)
        {
            var result = false;
            if(obj is HouseBookingReportBasicModel house)
            {
                result = this.Id == house.Id ;
            }
            return result;
        }
       public HouseBookingReportBasicModel(House house, Report report)
       {
           this.Id= house.Id;
           this.HouseName= house.Name;
           this.cantBooking = 0; // calcular ese número 
       }
    }
}