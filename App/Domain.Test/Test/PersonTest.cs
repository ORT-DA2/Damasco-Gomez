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
                    Password = null,
                };

            person.Update(newPerson);

            Assert.AreEqual(newPerson.Email, person.Email);
        }
        [TestMethod]
        public void TestUpdatePassword()
        {
            Person newPerson = new Person()
                {
                    Email = null,
                    Password = "new p",
                };

            person.Update(newPerson);

            Assert.AreEqual(newPerson.Password, person.Password);
        }
        [TestMethod]
        public void TestId()
        {
            int id = 1;
            Person newPerson = new Person()
            {
                Id = id,
                Email = null,
                Password = "new p",
            };

            Assert.AreEqual(id, newPerson.Id);
        }
    }
}