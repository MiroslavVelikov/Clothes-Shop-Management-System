namespace TestEmployee
{
    using Data.Entities;
    using NUnit.Framework;

    public class Tests
    {
        [Test]
        public void EmployeeIdTest()
        {
            Employee employee = new Employee();
            employee.Id = 1;

            Assert.AreEqual(1, employee.Id, "Employee Id is different");
        }

        [Test]
        public void EmployeeRoleTest()
        {
            Employee employee = new Employee();
            employee.Role = "Admin";

            Assert.AreEqual("Admin", employee.Role, "Employee has a different name");
        }

        [Test]
        public void EmployeeNameTest()
        {
            Employee employee = new Employee();
            employee.Name = "George";

            Assert.AreEqual("George", employee.Name, "Employee has a different name");
        }


        [Test]
        public void EmployeePasswordTest()
        {
            Employee employee = new Employee();
            employee.Password = "IamGeorge1236";

            Assert.AreEqual("IamGeorge1236", employee.Password, "Employee works in a different city");
        }


        [Test]
        public void EmployeeCityTest()
        {
            Employee employee = new Employee();
            employee.City = "Aytos";

            Assert.AreEqual("Aytos", employee.City, "Employee work in a different");
        }
    }
}