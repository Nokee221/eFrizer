using eFrizer.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eFrizer.Win
{
    public partial class frmLoyalty : Form
    {
        private APIService _bonuses = new APIService("HairSalonServiceLoyaltyBonus");
        private APIService _services = new APIService("HairSalonService");

        public frmLoyalty()
        {
            InitializeComponent();
        }

        private async void Loyalty_Load(object sender, EventArgs e)
        {
            await LoadHairSalonServices();
        }

        private async Task LoadHairSalonServices()
        {
            var services = await _services.Get<List<HairSalonService>>();
            cmbService.DataSource = services;
            cmbService.DisplayMember = "ServiceName";
            cmbService.ValueMember = "Id";
        }
    }
}
