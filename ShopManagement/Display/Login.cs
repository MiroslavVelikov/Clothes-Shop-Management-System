namespace Display
{
    using System;
    using Business;
    using System.Windows.Forms;
    using Data.Entities;

    public partial class Login : Form
    {
        private EmployeeBusiness employeeBusiness = new EmployeeBusiness();
        private LastLogBusiness lastLogBusiness = new LastLogBusiness();

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void typeBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void usernameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            var username = usernameBox;
            var password = passwordBox;
            var role = roleBox;
            var employees = employeeBusiness.GetAll();
            
            var log = lastLogBusiness.Get(1);
            log.Name = username.Text;
            log.Password = password.Text;
            log.Role = role.Text;
            log.IsLogedIn = true;
            lastLogBusiness.Update(log);

            foreach (var employee in employees)
            {
                if (employee.Name == username.Text
                    && employee.Password == password.Text
                    && employee.Role == role.Text)
                {
                    this.Hide();

                    if (role.Text == "Manager" || role.Text == "Select Role")
                    {
                        var adminMenu = new AdminMenu();
                        adminMenu.Show();
                    }
                    else
                    {
                        var employeeJob = new EmployeeJob(employee.Name, employee.Password);
                        employeeJob.Show();
                    }
                }
            }

            wrongPassword.Text = "Wrong password!";
            password.Text = "";
        }
    }
}
