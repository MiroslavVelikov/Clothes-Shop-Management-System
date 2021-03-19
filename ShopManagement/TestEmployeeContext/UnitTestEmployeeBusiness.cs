namespace TestEmployeeContext
{
    using Business;
    using Data.Entities;
    using NUnit.Framework;
    using System.Collections.Generic;

    public class Tests
    {
        private EmployeeBusiness employeeBusiness = new EmployeeBusiness();

        [Test]
        public void EmployeeCanBeAddedToDatabase()
        {
            Employee employee = new Employee
            {
                Name = "Stoyan",
                Role = "Admin",
                Password = "StoyanTodorov12435",
                City = "Aytos"
            };

            Assert.AreEqual("The employee was added", employeeBusiness.Add(employee),
                "Employee can not be added to database");
        }

        [Test]
        public void GetAllEmployeesFromDatabase()
        {
            List<Employee> employees = employeeBusiness.GetAll();

            Assert.AreEqual(employees.Count, employeeBusiness.GetAll().Count, "Employee cant be added to database");
        }

        [Test]
        public void EmployeeCanBeFoundById()
        {
            var employees = employeeBusiness.GetAll();
            var lastEmployeeId = employees[employees.Count - 1].Id;

            Assert.AreEqual(lastEmployeeId, employeeBusiness.Get(lastEmployeeId).Id,
                "This employee has a different Id");
        }

        [Test]
        public void UpdatingEmployee()
        {

            var employees = employeeBusiness.GetAll();
            var employee = employees[employees.Count - 1];
            var clotheId = employee.Id;
            employee.Name = "Changed";
            employeeBusiness.Update(employee);

            Assert.AreEqual("Changed", employeeBusiness.Get(clotheId).Name, "Employee had to change");
        }

        [Test]
        public void DeletingEmployee()
        {
            var employees = employeeBusiness.GetAll();
            var employeeId = employees[employees.Count - 1].Id;

            Assert.AreEqual("Employee was deleted", employeeBusiness.Delete(employeeId),
                "Employee has a different name");
        }

        [Test]
        public void DeletingNotExistingEmployee()
        {
            const int notExistingId = 9999999;

            Assert.AreEqual("Employee does not exist", employeeBusiness.Delete(notExistingId),
                "Employee exist");
        }

    }
}