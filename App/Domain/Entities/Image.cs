using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    public class Image
    {
        public int Id {get ; set ;}
        public string Entity {get; set;}
        public string Name {get; set;}
        [ExcludeFromCodeCoverage]
        public Image(string name, string entity)
        {
            this.Name = name;
            this.Entity = entity;
        }
    }
}