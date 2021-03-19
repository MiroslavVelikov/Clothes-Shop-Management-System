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
        private int editId = 0;

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

        private void AdminClothes_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UpdateTextboxes(int id)
        {
            var clothe = clotheBusiness.Get(id);
            var type = txtType;
            var name = txtName;
            var quantity = txtQuantity;
            var price = txtPrice;
            var sex = txtSex;
            var city = txtCity;

            type.Text = clothe.Type;
            name.Text = clothe.Name;
            price.Text = clothe.Price.ToString();
            quantity.Value = clothe.Quantity;
            price.Text = clothe.Price.ToString();
            sex.Text = clothe.Sex;
            city.Text = clothe.City;
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

        private bool CityCheck(string city)
        {
            if (city == "Sofia" || city == "Plovdiv" || city == "Varna" || city == "Burgas")
                return true;

            return false;
        }

        private void ClearBoxes()
        {
            txtType.Text = "";
            txtName.Text = "";
            txtQuantity.Value = 0;
            txtPrice.Text = "";
            txtSex.Text = "";
            txtCity.Text = "";
        }

        private Clothe GetEditedProduct()
        {
            var clothe = new Clothe();
            clothe.Id = editId;

            decimal price = 0;
            decimal.TryParse(txtPrice.Text, out price);
            clothe.Type = txtType.Text;
            clothe.Name = txtName.Text;
            clothe.Quantity = int.Parse(txtQuantity.Value.ToString());
            clothe.Price = price;
            clothe.Sex = txtSex.Text;
            clothe.City = txtCity.Text;

            return clothe;
        }

        // Buttons
        private void label10_Click(object sender, EventArgs e)
        {
            var login = new AdminMenu();
            this.Hide();
            login.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (clothesGrid.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("No entry selected", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var item = clothesGrid.SelectedRows[0].Cells;
                var id = int.Parse(item[0].Value.ToString());
                editId = id;
                UpdateTextboxes(id);
                ToggleSaveUpdate();
                DisableSelect();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var editedClothe = GetEditedProduct();
            clotheBusiness.Update(editedClothe);
            UpdateGrid();
            ResetSelect();
            ToggleSaveUpdate();
            ClearBoxes();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            var clothes = clotheBusiness.GetAll();
            if (clotheType.Text != "All")
                clothes = clothes.Where(x => x.Type == clotheType.Text).ToList();

            clothesGrid.DataSource = clothes;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (clothesGrid.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("No entry selected", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var item = clothesGrid.SelectedRows[0].Cells;
                var id = int.Parse(item[0].Value.ToString());
                clotheBusiness.Delete(id);
                UpdateGrid();
                ResetSelect();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var type = txtType;
            var name = txtName;
            var quantity = txtQuantity;
            var price = txtPrice;
            var sex = txtSex;
            var city = txtCity;
            const bool delivered = false;


            if (String.IsNullOrWhiteSpace(type.Text) || String.IsNullOrWhiteSpace(name.Text)
            || String.IsNullOrWhiteSpace(txtCity.Text) || !CityCheck(city.Text)
            || quantity.Value == 0 || decimal.Parse(price.Text) <= 0)
            {
                MessageBox.Show("One or more entries are empty", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    City = city.Text,
                    Delivered = delivered
                };
                clotheBusiness.Add(clothe);
            }

            ClearBoxes();
            UpdateGrid();
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            var logout = new Login();
            this.Hide();
            logout.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
