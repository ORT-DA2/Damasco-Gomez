using System.Diagnostics.CodeAnalysis;
using Domain;

namespace Model.In
{
    [ExcludeFromCodeCoverage]
    public class RegionModel
    {
        public string Name {get; set;}
        public Region ToEntity()
        {
            return new Region()
            {
                Name= this.Name
            };
        }
    }
}