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
        [ExcludeFromCodeCoverage]
        public Image()
        {
        }
        public void Update(Image element)
        {
            if(element.Name != null) this.Name = element.Name;
        }
    }
}