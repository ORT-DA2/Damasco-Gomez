using Domain;

namespace Model.In
{
    public class PersonModel
    {
        public string Email {get; set;}
        public string Password {get; set;}
        public Person ToEntity()
        {
            return new Person()
            {
                Email = this.Email,
                Password = this.Password,
            };
        }
    }
}