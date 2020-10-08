using System;

namespace Domain.Entities
{
    public class SessionUser
    {
        public int Id {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public Guid Token   {get; set;}
        public int PersonId  {get; set;}
        public Person User {get; set;}

    }
}