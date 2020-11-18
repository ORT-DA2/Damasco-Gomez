using System.Diagnostics.CodeAnalysis;
using Domain;

namespace Model.In
{
    [ExcludeFromCodeCoverage]
    public class PersonModel
    {
        public string Email {get; set;}
        public string Name {get; set;}
        public string Password {get; set;}
        public Person ToEntity()
        {
            return new Person()
            {
                Email = this.Email,
                Password = this.Password,
                Name= this.Name,
            };
        }
    }
}