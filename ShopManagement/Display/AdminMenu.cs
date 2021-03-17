using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Display
{
    public partial class AdminMenu : Form
    {
        public AdminMenu(string username)
        {
            InitializeComponent();
            usernameLabel.Text = username;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
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
    }
}
