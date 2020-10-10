using System;

namespace Domain.Entities
{
    public class SessionUser
    {
        public int Id {get; set;}
        public Guid Token   {get; set;}
        public int PersonId  {get; set;}
        public virtual Person User {get; set;}
        public void Update(Guid token)
        {
             this.Token = token;
        }

    }
}