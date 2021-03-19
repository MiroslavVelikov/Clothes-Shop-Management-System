namespace Display
{
    using System;
    using Business;
    using System.Windows.Forms;

    public partial class AdminMenu : Form
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            var lastLogBusiness = new LastLogBusiness();
            var log = lastLogBusiness.Get(1);
            log.IsLogedIn = false;
            lastLogBusiness.Update(log);
            
            var logout = new Login();
            this.Hide();
            logout.Show();
        }

        private void AdminMenu_Load(object sender, EventArgs e)
        {

        }

        private void AdminMenu_Load_1(object sender, EventArgs e)
        {

        }

        private void clothesBtn_Click(object sender, EventArgs e)
        {
            var clothes = new AdminClothes();
            this.Hide();
            clothes.Show();
        }

        private void workersBtn_Click(object sender, EventArgs e)
        {
            var employees = new AdminEmployees();
            this.Hide();
            employees.Show();
        }
    }
}
