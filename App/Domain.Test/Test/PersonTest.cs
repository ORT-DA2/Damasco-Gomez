using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Test.Test
{
    [TestClass]
    public class PersonTest
    {
        public Person person;
        [TestInitialize]
        public void SetUp()
        {
            person = new Person()
                {
                    Id = 2,
                    Email = "mail2@mail.com",
                    Password = "password",
                };
        }
        [TestMethod]
        public void TestUpdateEmail()
        {
            Person newPerson = new Person()
                {
                    Email = "new mail",
                    Password = "",
                };

            Person.Update(person,newPerson);

            Assert.AreEqual(newPerson.Email, person.Email);
        }
        [TestMethod]
        public void TestUpdatePassword()
        {
            Person newPerson = new Person()
                {
                    Email = "",
                    Password = "new p",
                };

            Person.Update(person,newPerson);

            Assert.AreEqual(newPerson.Password, person.Password);
        }
    }
}