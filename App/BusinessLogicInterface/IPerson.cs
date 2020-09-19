namespace BusinessLogicInterface
{
    public interface IPerson
    {
         void CreateUser(string token);

         void SetPassword(int id, string token);

         void UpdateEmail(int id, string email, string token);

         void UpdatePassword(int id, string password, string token);

         void UpdateName(int id, string name, string token);
    }
}