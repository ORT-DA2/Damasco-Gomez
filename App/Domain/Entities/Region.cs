using System.Diagnostics.CodeAnalysis;

namespace Domain
{
    public class Region
    {
        public int Id {get; set; }
        public string Name {get; set;}
        //public virtual List<TouristPoint> TouristPoints {get; set;}
        [ExcludeFromCodeCoverage]
        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is Region region)
            {
                result = this.Id == region.Id ;
            }
            return result;
        }
        public void Update(Region element)
        {
            if(element.Name != null) this.Name = element.Name;
        }
    }
}
