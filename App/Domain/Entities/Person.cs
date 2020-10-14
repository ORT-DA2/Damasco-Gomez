using System;
using System.Diagnostics.CodeAnalysis;

namespace Domain
{
    public class Person
    {
        public int Id {get; set;}

        public string Email {get; set;}

        public string Password {get; set;}
        [ExcludeFromCodeCoverage]
        public override bool Equals(object obj)
        {
            var result = false;
            if(obj is Person person)
            {
                result = this.Id == person.Id ;
            }
            return result;
        }
        public void Update(Person element)
        {
            if(element.Password != null) this.Password = element.Password;
            if(element.Email != null) this.Email = element.Email;
        }

    }
}