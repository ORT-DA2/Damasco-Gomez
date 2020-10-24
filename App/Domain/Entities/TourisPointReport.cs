using System;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    public class TourisPointReport
    {
        [ExcludeFromCodeCoverage]
        public int IdTp {get; set;}
        public  DateTime DateFrom {get; set;}
        public DateTime DateTo {get; set;}
    }
}