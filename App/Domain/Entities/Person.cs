using System;
namespace Domain
{
    public class Person
    {
        public int Id {get; set;}

        public string Email {get; set;}

        public string Password {get; set;}

        public override bool Equals(object obj)
        {
            var result = false;
            if(obj is Person person)
            {
                result = this.Id == person.Id ;
            }
            return result;
        }
        public static void Update(Person elementToUpdate, Person element)
        {
            if(element.Password != null) elementToUpdate.Password = element.Password;
            if(element.Email != null) elementToUpdate.Email = element.Email;
        }

    }
}