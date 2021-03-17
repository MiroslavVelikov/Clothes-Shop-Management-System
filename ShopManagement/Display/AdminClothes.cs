namespace Display
{
    using System;
    using Business;
    using Data.Entities;
    using System.Windows.Forms;
    using System.Linq;

    public partial class AdminClothes : Form
    {
        private ClotheBusiness clotheBusiness = new ClotheBusiness();
        private string clotheName;

        public AdminClothes()
        {
            InitializeComponent();
            UpdateGrid();
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;
        }

        private void UpdateGrid()
        {
            clothesGrid.DataSource = clotheBusiness.GetAll();
            clothesGrid.ReadOnly = true;
            clothesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AdminClothes_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            var login = new AdminMenu();
            this.Hide();
            login.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            var logout = new Login();
            this.Hide();
            logout.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var type = txtType;
            var name = txtName;
            var quantity = txtQuantity;
            var price = txtPrice;
            var sex = txtSex;
            var sector = txtSector;
            var city = txtCity;
            const bool delivered = false;

            if (type.Text == "" || name.Text == "" || quantity.Value == 0 
                || decimal.Parse(price.Text) <= 0 || !SectorCheck(sector.Text) || !CityCheck(city.Text))
            {
                wrongInput.Text = "Wrong input";
            }
            else
            {
                var clothe = new Clothe()
                {
                    Type = type.Text,
                    Name = name.Text,
                    Quantity = int.Parse(quantity.Value.ToString().Split('.')[0]),
                    Price = decimal.Parse(price.Text),
                    Sex = sex.Text,
                    Sector = sector.Text,
                    City = city.Text,
                    Delivered = delivered
                };
                clotheBusiness.Add(clothe);

                wrongInput.Text = "";
            }

            ClearBoxes();
            UpdateGrid();
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (clothesGrid.SelectedRows.Count > 0)
            {
                var item = clothesGrid.SelectedRows[0].Cells;
                var id = int.Parse(item[0].Value.ToString());
                clotheBusiness.Delete(id);
                UpdateGrid();
                ResetSelect();
            }
        }

        private void refreshBnt_Click(object sender, EventArgs e)
        {
            var clothes = clotheBusiness.GetAll();
            if (clotheType.Text != "All")
                clothes = clothes.Where(x => x.Type == clotheType.Text).ToList();

            clothesGrid.DataSource = clothes;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (clothesGrid.SelectedRows.Count > 0)
            {
                var item = clothesGrid.SelectedRows[0].Cells;
                var id = int.Parse(item[0].Value.ToString());
                UpdateTextboxes(id);
                ToggleSaveUpdate();
                DisableSelect();
            }
        }

        private void UpdateTextboxes(int id)
        {
            var clothe = clotheBusiness.Get(id);
            var type = txtType;
            var name = txtName;
            var quantity = txtQuantity;
            var price = txtPrice;
            var sex = txtSex;
            var sector = txtSector;
            var city = txtCity;

            type.Text = clothe.Type;
            name.Text = clothe.Name;
            price.Text = clothe.Price.ToString();
            quantity.Value = clothe.Quantity;
            price.Text = clothe.Price.ToString();
            sex.Text = clothe.Sex;
            sector.Text = clothe.Sector;
            city.Text = clothe.City;

            clotheName = name.Text;
        }

        private void ToggleSaveUpdate()
        {
            if (btnUpdate.Enabled)
            {
                btnSave.Enabled = true;
                btnUpdate.Enabled = false;
            }
            else
            {
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
            }
        }

        private void DisableSelect()
        {
            clothesGrid.Enabled = false;
        }

        private void ResetSelect()
        {
            clothesGrid.ClearSelection();
            clothesGrid.Enabled = true;
        }

        private bool SectorCheck(string sector)
        {
            if (sector == "A" || sector == "B" || sector == "C" || sector == "D")
                return true;

            return false;
        }

        private bool CityCheck(string city)
        {
            if (city == "Sofia" || city == "Plovdiv" || city == "Varna" || city == "Burgas")
                return true;

            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var clothe = clotheBusiness.GetAll().Where(x => x.Name == clotheName).ToList();

            var editedClothe = new Clothe()
            {
                Type = txtType.Text,
                Name = txtName.Text,
                Quantity = int.Parse(txtQuantity.Value.ToString().Split('.')[0]),
                Price = decimal.Parse(txtPrice.Text),
                Sex = txtSex.Text,
                Sector = txtSector.Text,
                City = txtCity.Text,
                Delivered = clothe[0].Delivered
            };

            clotheBusiness.Update(editedClothe);
            UpdateGrid();
            ResetSelect();
            ToggleSaveUpdate();
            ClearBoxes();
        }

        private void ClearBoxes()
        {
            txtType.Text = "";
            txtName.Text = "";
            txtQuantity.Value = 0;
            txtPrice.Text = "";
            txtSex.Text = "";
            txtSector.Text = "";
            txtCity.Text = "";
        }
    }
}
