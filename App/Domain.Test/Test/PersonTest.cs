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
                    Name = "Name"
                };
        }
        [TestMethod]
        public void TestUpdateEmail()
        {
            Person newPerson = new Person()
                {
                    Email = "new mail",
                    Password = null,
                    Name = null,
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
                    Name = null,
                };

            person.Update(newPerson);

            Assert.AreEqual(newPerson.Password, person.Password);
        }
        [TestMethod]
        public void TestUpdateName()
        {
            string newName = "new Name";
            person = new Person()
                {
                    Email = null,
                    Password = null,
                    Name = newName
                };

            person.Update(person);

            Assert.AreEqual(person.Name, newName);
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