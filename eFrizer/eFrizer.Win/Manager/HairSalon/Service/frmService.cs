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

namespace eFrizer.Win.Service
{
    public partial class frmService : Form
    {
        private HairSalon _hairSalon { get; set; }
        private readonly APIService _hairsalonservices = new APIService("HairSalonService");
        private readonly APIService _services = new APIService("Service");
        public frmService(HairSalon hairSalon)
        {
            InitializeComponent();
            dgvServices.AutoGenerateColumns = false;
            txtServiceId.Visible = false;
            _hairSalon = hairSalon;
        }

        private async void frmService_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            await LoadServices();
        }

        private async Task LoadServices()
        {
            var result = await _hairsalonservices.Get<List<HairSalonService>>(new HairSalonService() { HairSalonId = _hairSalon.HairSalonId });

            dgvServices.DataSource = result;
        }

        private async void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" && txtDesc.Text == "" && txtPrice.Text == "")
                return;

            var request = new ServiceUpdateRequest();
            request.Name = txtName.Text;

            var service = await _services.Update<Model.Service>(int.Parse(txtServiceId.Text), request);
            await LoadData();

        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            var request = new HairSalonServiceInsertRequest()
            {
                Name = txtName.Text,
                Description = txtDesc.Text,
                Price = int.Parse(txtPrice.Text),
                TimeMin = int.Parse(txtTime.Text),
                HairSalonId = _hairSalon.HairSalonId
            };

            var hairsalonservice = await _hairsalonservices.Insert<HairSalonService>(request);
            await LoadData();
        }

        private void dgvServices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var item = dgvServices.SelectedRows[0].DataBoundItem as HairSalonService;

            txtServiceId.Text = item.ServiceId.ToString();
            txtName.Text = item.ServiceName;
            txtDesc.Text = item.Description;
            txtPrice.Text = item.Price.ToString();
            txtTime.Text = item.TimeMin.ToString();
        }

        private async void txtView_Click(object sender, EventArgs e)
        {
            HairSalonServiceSearchRequest request = new HairSalonServiceSearchRequest()
            {
                Name = txtSearch.Text
            };

            var result = await _hairsalonservices.Get<List<HairSalonService>>(request);
            dgvServices.DataSource = result;

        }
    }
}
