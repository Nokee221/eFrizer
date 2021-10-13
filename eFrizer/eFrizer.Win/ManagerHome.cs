using eFrizer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eFrizer.Win
{
    public partial class ManagerHome : Form
    {
        private readonly APIService _hairSalons = new APIService("HairSalonManager");
        private readonly APIService _managerService = new APIService("Manager");
        private readonly Manager _user;

        public ManagerHome(Manager user)
        {
            InitializeComponent();
            dgvManagerHome.AutoGenerateColumns = false;
            _user = user;
        }

        private async Task LoadData()
        {
            //await LoadManager();
            await LoadHairSalons();
            txtName.Enabled = false;
            txtUserName.Enabled = false;
            txtSurname.Enabled = false;
            await LoadInfo();
        }

        private async Task LoadHairSalons()
        {
            var result = await _hairSalons.Get<List<HairSalonManager>>(new HairSalonManagerSearchRequest() { ManagerId = _user.ApplicationUserId});
            
            dgvManagerHome.DataSource = result;
        }

        private async void ManagerHome_Load(object sender, EventArgs e)
        {
            await LoadData();

        }

        private async Task LoadInfo()
        {
            txtName.Text = _user.Name;
            txtSurname.Text = _user.Surname;
            txtUserName.Text = _user.Username;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtName.Enabled = true;
            txtUserName.Enabled = true;
            txtSurname.Enabled = true;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            ManagerUpadateRequest request = new ManagerUpadateRequest()
            {
                Name = txtName.Text,
                Surname = txtSurname.Text,
                UserName = txtUserName.Text
            };

            var manager = _managerService.Update<Manager>(_user.ApplicationUserId, request);

            MessageBox.Show("SUCCESSFULLY UPDATED", "UPDATE");
            
        }

        private async void btn_Click(object sender, EventArgs e)
        {
            HairSalonManagerInsertRequest request = new HairSalonManagerInsertRequest()
            {
                Name = txtHairSalonName.Text,
                Address = txtHairsalonAddress.Text,
                Description = txtHairsalonDesc.Text,
                ManagerId = _user.ApplicationUserId

            };

            var hairsalonmanager = await _hairSalons.Insert<HairSalonManager>(request);


            MessageBox.Show("Successfully added new hair salon!");
            txtHairSalonName.Clear();
            txtHairsalonAddress.Clear();
            txtHairsalonDesc.Clear();
            LoadData();
        }

        private async void dgvManagerHome_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvManagerHome.SelectedRows[0].DataBoundItem as HairSalonManager;
            
            var form = new frmHairSalon(item.HairSalon).ShowDialog();

            await LoadData();
        }







        //private Task LoadManager()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
