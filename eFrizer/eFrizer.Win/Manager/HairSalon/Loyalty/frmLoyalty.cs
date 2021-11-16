using eFrizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
            LoadActivatesOn();
            LoadExpiresIn();
        }

        private void LoadExpiresIn()
        {
            var options = new List<int>();
            options.AddRange(Enumerable.Range(1, 30));
            var optionsText = new List<string>();
            foreach (var item in options)
            {
                var ending = (item == 1) ? " day" : " days";
                optionsText.Add(item.ToString() + ending);
            }
            cbExpiration.DataSource = optionsText;
        }

        private void LoadActivatesOn()
        {
            var options = new List<int>();
            options.AddRange(Enumerable.Range(1, 7));
            var optionsText = new List<string>();
            foreach (var item in options)
            {
                var ending = (item == 1) ? " purchase" : " purchases";
                optionsText.Add(item.ToString() + ending);
            }
            cbActivatesOn.DataSource = optionsText;
        }

        private async Task LoadHairSalonServices()
        {
            var services = await _services.Get<List<HairSalonService>>();
            cbService.DataSource = services;
            cbService.DisplayMember = "ServiceName";
            cbService.ValueMember = "Id";
        }
    }
}
