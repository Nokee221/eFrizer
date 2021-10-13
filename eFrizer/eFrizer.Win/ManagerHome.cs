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

        private void dgvManagerHome_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvManagerHome.SelectedRows[0].DataBoundItem as HairSalonManager;
            
            var form = new frmHairSalon(item.HairSalon).ShowDialog();

        }

        //private Task LoadManager()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
