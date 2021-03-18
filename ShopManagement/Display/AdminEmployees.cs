using System;
using Data.Entities;
using Data;
using Business;
using System.Windows.Forms;

namespace Display
{
    public partial class AdminEmployees : Form
    {
        private EmployeeBusiness employeeBusiness;
        private Employee employee;
        public AdminEmployees()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(RoleTxt.Text) || String.IsNullOrWhiteSpace(NameTxt.Text)
                || String.IsNullOrWhiteSpace(PasswordTxT.Text) || String.IsNullOrWhiteSpace(CityDropBoxTxt.Text))
            {
                MessageBox.Show("One or more entries are empty", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                employee = new Employee
                {
                    Role = RoleTxt.Text,
                    Name = NameTxt.Text,
                    Password = PasswordTxT.Text,
                    City = CityDropBoxTxt.Text
                };
                try
                {
                    employeeBusiness.Add(employee);
                }
                catch (Exception)
                {
                    employeeBusiness = new EmployeeBusiness();
                    employeeBusiness.Add(employee);
                }
            }
        }
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (EmployeeGrid.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("No entry selected", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                employee = EmployeeGrid.CurrentRow.DataBoundItem as Employee;
                employeeBusiness.Delete(employee.Id);
            }
        }
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (EmployeeGrid.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("No entry selected", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                employee = EmployeeGrid.CurrentRow.DataBoundItem as Employee;

                if (String.IsNullOrWhiteSpace(RoleTxt.Text) || String.IsNullOrWhiteSpace(NameTxt.Text)
                || String.IsNullOrWhiteSpace(PasswordTxT.Text) || String.IsNullOrWhiteSpace(CityDropBoxTxt.Text))
                {
                    MessageBox.Show("One or more entries are empty", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    employee.Role = RoleTxt.Text;
                    employee.Name = NameTxt.Text;
                    employee.Password = PasswordTxT.Text;
                    employee.City = CityDropBoxTxt.Text;
                    employeeBusiness.Update(employee);
                }
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
