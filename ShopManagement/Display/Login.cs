using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data.Entities;

namespace Display
{
    public partial class Login : Form
    {
        private EmployeeBusiness employeeBusiness = new EmployeeBusiness();

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

            foreach (var employee in employees)
            {
                if (employee.Name == username.Text 
                    && employee.Password == password.Text 
                    && employee.Role == role.Text)
                {
                    var login = new AdminMenu(username.Text);
                    this.Hide();
                    login.Show();
                }
            }

            wrongPassword.Text = "Wrong password!";
            password.Text = "";
        }
    }
}
