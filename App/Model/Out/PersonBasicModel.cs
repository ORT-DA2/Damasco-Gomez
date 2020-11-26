using Domain;

namespace Model.Out
{
    public class PersonBasicModel
    {
        public int Id {get; set;}
        public string Email {get; set;}
        public string Name {get; set;}
        public PersonBasicModel(Person person)
        {
            this.Id = person.Id;
            this.Email = person.Email;
            this.Name = person.Name;
        }
        public override bool Equals(object obj)
        {
            var result = false;
            if(obj is PersonBasicModel person)
            {
                result = this.Id == person.Id ;
            }
            return result;
        }
    }
}