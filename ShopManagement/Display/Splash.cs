namespace Display
{
    using System;
    using Business;
    using System.Windows.Forms;

    public partial class Splash : Form
    {
        private LastLogBusiness log = new LastLogBusiness();

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
                var user = log.Get(1);

                if (user.IsLogedIn)
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
                    var login = new Login();
                    this.Hide();
                    login.Show();
                }
            }
        }
    }
}
