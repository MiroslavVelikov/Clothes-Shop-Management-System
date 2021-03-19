namespace Display
{
    using System;
    using Business;
    using System.Data;
    using System.Linq;
    using Data.Entities;
    using System.Windows.Forms;
    using System.Collections.Generic;

    public partial class EmployeeJob : Form
    {
        private ClotheBusiness clotheBusiness = new ClotheBusiness();
        private EmployeeBusiness employeeBusiness = new EmployeeBusiness();

        public EmployeeJob(string username, string password)
        {
            InitializeComponent();
            txtCityName.Text = GetCityName(username, password);
            LoadGrid();
        }

        private string GetCityName(string username, string password)
        {
            return employeeBusiness.GetAll().Where(x => x.Name == username && x.Password == password).ToList()[0].City;
        }

        private void LoadGrid()
        {
            gridNotDelivered.DataSource = clotheBusiness.GetAll()
                .Where(x => x.Delivered == false && x.City == txtCityName.Text).ToList();
            gridNotDelivered.ReadOnly = true;
            gridNotDelivered.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            gridDelivered.DataSource = clotheBusiness.GetAll()
                .Where(x => x.Delivered == true && x.City == txtCityName.Text).ToList();
            gridDelivered.ReadOnly = true;
        }

        private void UpdateGrid(List<Clothe> clothes)
        {
            gridNotDelivered.DataSource = clothes
                .Where(x => x.Delivered == false && x.City == txtCityName.Text).ToList();
            gridDelivered.DataSource = clothes
                .Where(x => x.Delivered == true && x.City == txtCityName.Text).ToList();
        }

        private void DisableSelect()
        {
            gridNotDelivered.Enabled = false;
        }
        // Buttons
        private void btnExit_Click(object sender, EventArgs e)
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (txtType.Text == "All")
                UpdateGrid(clotheBusiness.GetAll());
            else
                UpdateGrid(clotheBusiness.GetAll().Where(x => x.Type == txtType.Text).ToList());
        }

        private void btnDeliver_Click(object sender, EventArgs e)
        {
            if (gridNotDelivered.SelectedRows.Count > 0)
            {
                var item = gridNotDelivered.SelectedRows[0].Cells;
                var id = int.Parse(item[0].Value.ToString());
                var clothe = clotheBusiness.Get(id);
                clothe.Delivered = true;
                clotheBusiness.Update(clothe);

                DisableSelect();
                LoadGrid();
            }
        }
    }
}
