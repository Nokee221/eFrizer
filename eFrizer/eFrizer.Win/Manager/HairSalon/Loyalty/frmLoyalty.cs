using eFrizer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Mvc;
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

        internal class ActivationTrigger
        {
            public int AmountOfPurchases { get; set; }
            public string Text { get; set; }
        }

        internal class ExpirationTime
        {
            public int AmountOfDays { get; set; }
            public string Text { get; set; }
        }

        private async void Loyalty_Load(object sender, EventArgs e)
        {
            await LoadBonuses();
            await LoadHairSalonServices();
            LoadActivatesOn();
            LoadExpiresIn();
        }

        private async Task LoadBonuses()
        {
            var bonuses = await _bonuses.Get<List<HairSalonServiceLoyaltyBonus>>();
            populate_dgvBonuses(bonuses);
        }

        private void populate_dgvBonuses(List<HairSalonServiceLoyaltyBonus> bonuses = null)
        {
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("ServiceName"),
                new DataColumn("Discount"),
                new DataColumn("Activation"),
                new DataColumn("Expiration"),
            });

            if (bonuses != null)
            {
                foreach (var item in bonuses)
                {
                    var row = dataTable.NewRow();
                    row["ServiceName"] = item.ServiceName;
                    row["Discount"] = item.Discount;
                    row["Activation"] = item.ActivatesOn;
                    row["Expiration"] = item.ExpiresIn;
                    dataTable.Rows.Add(row);
                }
            }

            dgvLoyalty.DataSource = dataTable;
            dgvLoyalty.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLoyalty.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void LoadExpiresIn()
        {
            int min = 1, max = 30;
            var options = new List<ExpirationTime>();
            for (int i = min; i < max; i++)
            {
                options.Add(new ExpirationTime
                {
                    AmountOfDays = i,
                    Text = i.ToString() + ((i == 1) ? " day" : " days")
                });
            }

            cbExpiration.DataSource = options;
            cbExpiration.DisplayMember = "Text";
            cbExpiration.ValueMember = "AmountOfDays";
        }

        private void LoadActivatesOn()
        {
            int min = 1, max = 30;
            var options = new List<ActivationTrigger>();
            for (int i = min; i < max; i++)
            {
                options.Add(new ActivationTrigger
                {
                    AmountOfPurchases = i,
                    Text = i.ToString() + ((i == 1) ? " purchase" : " purchases")
                });
            }

            cbActivatesOn.DataSource = options;
            cbActivatesOn.DisplayMember = "Text";
            cbActivatesOn.ValueMember = "AmountOfPurchases";
        }

        private async Task LoadHairSalonServices()
        {
            var services = await _services.Get<List<HairSalonService>>();
            cbService.DataSource = services;
            cbService.DisplayMember = "ServiceName";
            cbService.ValueMember = "Id";
        }

        private async void btnSaveBonus_Click(object sender, EventArgs e)
        {
            var req = new HairSalonServiceLoyaltyBonusInsertRequest()
            {
                HairSalonServiceId = Convert.ToInt32(cbService.SelectedValue),
                Discount = Convert.ToInt32(txtDiscount.Text),
                ActivatesOn = Convert.ToInt32(cbActivatesOn.SelectedValue),
                ExpiresIn = Convert.ToInt32(cbExpiration.SelectedValue)

            };

            var bonus = await _bonuses.Insert<HairDresser>(req);
            
            MessageBox.Show("Successfully added new loyalty bonus!");
            Close();
        }
    }
}
