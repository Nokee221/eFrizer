using eFrizer.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eFrizer.Win
{
    public partial class ManagerHome : Form
    {
        private readonly APIService _hairSalons = new APIService("HairSalon");
        private readonly APIService _managerService = new APIService("Manager");
        private APIService _cityService = new APIService("City");
        private APIService _hairSalonManagerService = new APIService("HairSalonManager");
        private Manager _user;

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
            await LoadCities();
            txtName.Enabled = false;
            txtUserName.Enabled = false;
            txtSurname.Enabled = false;
            LoadInfo();
        }

        private async Task LoadCities()
        {
            var cities = await _cityService.Get<List<City>>();
            cbCity.DataSource = cities;
            cbCity.DisplayMember = "Name";
            cbCity.ValueMember = "CityId";
        }

        private async Task LoadHairSalons()
        {
            var result = await _hairSalonManagerService.Get<List<HairSalonManager>>(new HairSalonManagerSearchRequest() { ManagerId = _user.ApplicationUserId});
            
            dgvManagerHome.DataSource = result;
        }

        private async void ManagerHome_Load(object sender, EventArgs e)
        {
            await LoadData();
         
        }

        private async void LoadInfo()
        {
            APIService _userEndpoint = new APIService("Login");
            _user = await _userEndpoint.Login<Manager>(APIService.Username, APIService.Password);
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

        private async void btnSaveChanges_Click(object sender, EventArgs e)
        {
            ManagerUpdateRequest request = new ManagerUpdateRequest()
            {
                Name = txtName.Text,
                Surname = txtSurname.Text,
                Username = txtUserName.Text
            };


            var manager = await _managerService.Update<Manager>(_user.ApplicationUserId, request);
            APIService.Username = request.Username;

            if (manager != null)
            {
                MessageBox.Show("Successfully updated user details.", "Success"); 
            }
            else
            {
                MessageBox.Show("Couldn't update user details.", "Failure");
            }

        }

        private async void btnAddHairSalon_Click(object sender, EventArgs e)
        {
            var req = new HairSalonInsertRequest()
            {
                Name = txtHairSalonName.Text,
                Address = txtHairsalonAddress.Text,
                Description = txtHairsalonDesc.Text,
                CityId = Convert.ToInt32(cbCity.SelectedValue)
            };

            var newHairSalon = await _hairSalons.Insert<HairSalon>(req);

            HairSalonManagerInsertRequest request = new HairSalonManagerInsertRequest()
            {
                HairSalonId = newHairSalon.HairSalonId,                
                ManagerId = _user.ApplicationUserId,
            };

            var hairsalonmanager = await _hairSalonManagerService.Insert<HairSalonManager>(request);


            MessageBox.Show("Successfully added new hair salon!");
            txtHairSalonName.Clear();
            txtHairsalonAddress.Clear();
            txtHairsalonDesc.Clear();
            await LoadData();
        }

        private async void dgvManagerHome_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var item = dgvManagerHome.SelectedRows[0].DataBoundItem as HairSalonManager;

            this.Hide();
            var form = new frmHairSalon(item.HairSalon, _user);
            form.Closed += (s, args) => this.Close();
            form.Show();

            await LoadData();
        }







        //private Task LoadManager()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
