namespace TestLastLog
{
    using Data.Entities;
    using NUnit.Framework;

    public class Tests
    {
        private LastLog log;

        [SetUp]
        public void SetUp()
        {
            log = new LastLog()
            {
                Id = 1,
                Role = "Manager",
                Name = "Test",
                Password = "Test",
                IsLogedIn = true
            };
        }

        [Test]
        public void LastLogIdTest()
        {
            Assert.AreEqual(log.Id, 1, "Log Id must be 1");
        }

        [Test]
        public void LastLogRoleTest()
        {
            Assert.AreEqual(log.Role, "Manager", "Log Role must be Manager");
        }

        [Test]
        public void LastLogNameTest()
        {
            Assert.AreEqual(log.Name, "Test", "Log Name must be Test");
        }

        [Test]
        public void LastLogPasswordTest()
        {
            Assert.AreEqual(log.Password, "Test", "Log Password must be Test");
        }

        [Test]
        public void LastLogIsLogedInTest()
        {
            Assert.AreEqual(log.IsLogedIn, true, "Log Name must be Test");
        }
    }
}