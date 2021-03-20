namespace LastLogBusiness
{
    using Business;
    using NUnit.Framework;
    using System.Collections.Generic;

    public class Tests
    {
        private LastLogBusiness lastLogBusiness;

        [SetUp]
        public void SetUp()
        {
            lastLogBusiness = new LastLogBusiness();
        }

        [Test]
        public void LastLogGet()
        {
            var name = lastLogBusiness.Get(1).Name;
            Assert.AreEqual(name, lastLogBusiness.Get(1).Name, "Names must be equal");
        }

        [Test]
        public void LastLogUpdate()
        {
            var newName = "Works";
            var log = lastLogBusiness.Get(1);
            log.Name = newName;
            lastLogBusiness.Update(log);

            Assert.AreEqual(newName, lastLogBusiness.Get(1).Name, "Element was not updated");
        }
    }
}