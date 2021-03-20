namespace Display
{
    using System;
    using Business;
    using System.Linq;
    using Data.Entities;
    using System.Windows.Forms;

    public partial class AdminEmployees : Form
    {
        private EmployeeBusiness employeeBusiness = new EmployeeBusiness();
        private Employee employee;
        private int editId = 0;

        public AdminEmployees()
        {
            InitializeComponent();
            UpdateGrid();
            SaveButton.Enabled = false;
            UpdateButton.Enabled = true;
        }

        private void ToggleSaveUpdate()
        {
            if (UpdateButton.Enabled)
            {
                SaveButton.Enabled = true;
                UpdateButton.Enabled = false;
            }
            else
            {
                SaveButton.Enabled = false;
                UpdateButton.Enabled = true;
            }
        }

        private void UpdateTextboxes(int id)
        {
            var employee = employeeBusiness.Get(id);
            var role = txtRole;
            var name = txtNam;
            var password = txtPassword;
            var city = txtCity;

            role.Text = employee.Role;
            name.Text = employee.Name;
            password.Text = employee.Password;
            city.Text = employee.City;
        }

        private void DisableSelect()
        {
            employeeGrid.Enabled = false;
        }

        private void UpdateGrid()
        {
            employeeGrid.DataSource = employeeBusiness.GetAll().Where(x => x.Name != "Admin0").ToList();
            employeeGrid.ReadOnly = true;
            employeeGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ClearBoxes()
        {
            txtRole.Text = "";
            txtNam.Text = "";
            txtPassword.Text = "";
            txtCity.Text = "";
        }

        private void ResetSelect()
        {
            employeeGrid.ClearSelection();
            employeeGrid.Enabled = true;
        }

        private Employee GetEditedProduct()
        {
            var employee = new Employee();
            employee.Id = editId;

            employee.Role = txtRole.Text;
            employee.Name = txtNam.Text;
            employee.Password = txtPassword.Text;
            employee.City = txtCity.Text;

            return employee;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        // Buttons
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (employeeBusiness.GetAll().Select(x => x.Name).Contains(txtNam.Text))
            {
                MessageBox.Show("User with the same name already exist", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (String.IsNullOrWhiteSpace(txtRole.Text) || String.IsNullOrWhiteSpace(txtNam.Text)
                || String.IsNullOrWhiteSpace(txtPassword.Text) || String.IsNullOrWhiteSpace(txtCity.Text))
            {
                MessageBox.Show("One or more entries are empty", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                employee = new Employee
                {
                    Role = txtRole.Text,
                    Name = txtNam.Text,
                    Password = txtPassword.Text,
                    City = txtCity.Text
                };

                employeeBusiness.Add(employee);
                ClearBoxes();
                UpdateGrid();
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (employeeGrid.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("No entry selected", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                employee = employeeGrid.CurrentRow.DataBoundItem as Employee;
                employeeBusiness.Delete(employee.Id);
            }

            UpdateGrid();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (employeeGrid.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("No entry selected", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                employee = employeeGrid.CurrentRow.DataBoundItem as Employee;

                var item = employeeGrid.SelectedRows[0].Cells;
                var id = int.Parse(item[0].Value.ToString());
                editId = id;
                UpdateTextboxes(id);
                ToggleSaveUpdate();
                DisableSelect();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var editedEmployee = GetEditedProduct();
            employeeBusiness.Update(editedEmployee);
            UpdateGrid();
            ResetSelect();
            ToggleSaveUpdate();
            ClearBoxes();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var lastLogBusiness = new LastLogBusiness();
            var log = lastLogBusiness.Get(1);
            log.IsLogedIn = false;
            lastLogBusiness.Update(log);
            var logout = new Login();
            this.Hide();
            logout.Show();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            var login = new AdminMenu();
            this.Hide();
            login.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            var employees = employeeBusiness.GetAll().Where(x => x.Name != "Admin0").ToList();
            if (txtCityType.Text != "All")
                employees = employees.Where(x => x.City == txtCityType.Text).ToList();

            employeeGrid.DataSource = employees;
        }

        
    }
}