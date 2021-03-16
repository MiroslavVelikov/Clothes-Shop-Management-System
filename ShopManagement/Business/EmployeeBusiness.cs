namespace Business
{
    using Data;
    using System.Linq;
    using Data.Entities;
    using System.Collections.Generic;

    public class EmployeeBusiness
    {
        private EmployeeContext employeeContext;

        /// <summary>
        /// Get all employees from the database
        /// </summary>
        public List<Employee> GetAll()
        {
            using (employeeContext = new EmployeeContext())
            {
                return employeeContext.Employees.ToList();
            }
        }

        /// <summary>
        /// Get single employee from the database by Id
        /// </summary>
        public Employee Get(int id)
        {
            using (employeeContext = new EmployeeContext())
            {
                return employeeContext.Employees.Find(id);
            }
        }

        /// <summary>
        /// Add a employee to the database
        /// </summary>
        public string Add(Employee employee)
        {
            using (employeeContext = new EmployeeContext())
            {
                employeeContext.Employees.Add(employee);
                employeeContext.SaveChanges();
            }

            return "The employee was added";
        }

        /// <summary>
        /// Update a single Employee in the database by Id.
        /// </summary>
        public void Update(Employee employee)
        {
            using (employeeContext = new EmployeeContext())
            {
                var item = employeeContext.Employees.Find(employee.Id);
                if (item != null)
                {
                    employeeContext.Entry(item).CurrentValues.SetValues(employee);
                    employeeContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Deleate an employee from the database by Id
        /// </summary>
        public string Delete(int id)
        {
            using (employeeContext = new EmployeeContext())
            {
                var employee = employeeContext.Employees.Find(id);
                if (employee != null)
                {
                    employeeContext.Employees.Remove(employee);
                    employeeContext.SaveChanges();
                    return "Employee was deleted";
                }

                return "Employee does not exist";
            }
        }
    }
}
