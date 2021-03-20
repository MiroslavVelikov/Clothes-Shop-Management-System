namespace Display
{
    using System;
    using Business;
    using Data.Entities;
    using System.Windows.Forms;

    public partial class Splash : Form
    {
        private LastLogBusiness lastLogBusiness = new LastLogBusiness();
        private EmployeeBusiness employeeBusiness = new EmployeeBusiness();
        private ClotheBusiness clotheBusiness = new ClotheBusiness();

        public Splash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar.Increment(2);
            if (progressBar.Value == 100)
            {
                timer1.Stop();
                var user = lastLogBusiness.Get(1);

                if (user != null && user.IsLogedIn)
                {
                    if (user.Role == "Manager" || user.Role == "Select Role")
                    {
                        var adminMenu = new AdminMenu();
                        this.Hide();
                        adminMenu.Show();
                    }
                    else
                    {
                        var employeeJob = new EmployeeJob(user.Name, user.Password);
                        this.Hide();
                        employeeJob.Show();
                    }
                }
                else
                {
                    if (lastLogBusiness.Get(1) == null)
                    {
                        var log = new LastLog();
                        lastLogBusiness.Add(log);
                    }
                    var login = new Login();
                    this.Hide();
                    login.Show();
                }
            }
            else if (progressBar.Value == 32)
            {
                // Make sure employee Db is created
                var employee = employeeBusiness.Get(1);

                if (employee == null)
                {
                    employee = new Employee()
                    {
                        Name = "Admin0",
                        Password = "",
                        Role = "Select Role"
                    };
                    employeeBusiness.Add(employee);
                }
            }
            else if (progressBar.Value == 58)
            {
                // Make sure clothe Db is created
                clotheBusiness.GetAll();
            }
        }
    }
}
