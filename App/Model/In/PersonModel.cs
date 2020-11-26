using System;
using Domain;

namespace Model.In
{
    public class PersonModel
    {
        public string Email {get; set;}
        public string Name {get; set;}
        public string Password {get; set;}
        public Person ToEntity(bool post = true)
        {
            if (post && this.AnyValueEmpty())
            {
                throw new ArgumentException("You need to put all values: email, password and name");
            }
            return new Person()
            {
                Email = this.Email,
                Password = this.Password,
                Name= this.Name,
            };
        }
        public bool AnyValueEmpty()
        {
            bool emailEmpty = this.Email == null;
            bool passwordEmpty = this.Password == null;
            bool nameEmpty = this.Name == null;
            return emailEmpty || passwordEmpty || nameEmpty;
        }
    }
}