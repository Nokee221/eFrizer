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
        private HairSalonService _selectedService { get; set; }
        private readonly APIService _hairSalonServiceService = new APIService("HairSalonService");
        private readonly APIService _serviceService = new APIService("Service");
        private readonly APIService _pictureStreamService = new APIService("PictureStream");
        private readonly APIService _hairSalonServicePictures = new APIService("HairSalonServicePicture");
        public frmService(HairSalon hairSalon)
        {
            InitializeComponent();
            dgvServices.AutoGenerateColumns = false;
            _hairSalon = hairSalon;
        }

        private async void frmService_Load(object sender, EventArgs e)
        {
            pbService.SizeMode = PictureBoxSizeMode.StretchImage;
            btnGallery.Visible = false;
            await LoadData();
        }

        private async Task LoadData()
        {
            await LoadServices();
        }

        private async Task LoadServices()
        {
            var result = await _hairSalonServiceService.Get<List<HairSalonService>>(new HairSalonService() { HairSalonId = _hairSalon.HairSalonId });

            dgvServices.DataSource = result;
        }

        private async void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" && txtDesc.Text == "" && txtPrice.Text == "")
                return;
            //TODO: add validation
            var request = new HairSalonServiceUpdateRequest();
            request.Name = txtName.Text;
            request.Price = int.Parse(txtPrice.Text);
            request.TimeMin = int.Parse(txtTime.Text);
            request.Description = txtDesc.Text;

            var service = await _hairSalonServiceService.Update<Model.HairSalonService>(_selectedService.HairSalonServiceId, request);
            if(service != null)
            {
                MessageBox.Show("Update Successful");
                await LoadData();
            }
            else
            {
                MessageBox.Show("Couldn't update the service.");
            }

        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            //TODO: validate this
            var request = new HairSalonServiceInsertRequest()
            {
                Name = txtName.Text,
                Description = txtDesc.Text,
                Price = int.Parse(txtPrice.Text),
                TimeMin = int.Parse(txtTime.Text),
                HairSalonId = _hairSalon.HairSalonId
            };

            var hairSalonService = await _hairSalonServiceService.Insert<HairSalonService>(request);
            if(hairSalonService != null)
            {
                MessageBox.Show("Added new service.");
                await LoadData();
            }
            else
            {
                MessageBox.Show("Couldn't add new service.");
            }
        }

        private async void dgvServices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            btnGallery.Visible = true;

            var item = dgvServices.SelectedRows[0].DataBoundItem as HairSalonService;

            txtName.Text = item.ServiceName;
            txtDesc.Text = item.Description;
            txtPrice.Text = item.Price.ToString();
            txtTime.Text = item.TimeMin.ToString();
            _selectedService = item;
            var request = new HairSalonServicePictureSearchRequest
            {
                HairSalonServiceId = item.HairSalonServiceId
            };
            await LoadPictures(request);
            //TODO: Refactor heavily, enable multiple images to be displayed too..
        }

        private async Task LoadPictures(HairSalonServicePictureSearchRequest request)
        {
            var pictures = await _hairSalonServicePictures.Get<List<HairSalonServicePicture>>(request);
            if (pictures.Count != 0)
            {
                renderPicture(pictures.Last().PictureId);
            }
            else
            {
                pbService.Image = null;
            }
        }

        //TODO: refactor into helper method
        private async void renderPicture(int selectedId)
        {
            ImageConverter converter = new ImageConverter();
            var pictureSource = await _pictureStreamService.GetImageStream<byte[]>(selectedId);
            pbService.Image = null;
            pbService.Image = (Image)converter.ConvertFrom(pictureSource);
        }

        private async void txtView_Click(object sender, EventArgs e)
        {
            HairSalonServiceSearchRequest request = new HairSalonServiceSearchRequest()
            {
                Name = txtSearch.Text
            };

            var result = await _hairSalonServiceService.Get<List<HairSalonService>>(request);
            dgvServices.DataSource = result;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private async void btnGallery_Click(object sender, EventArgs e)
        {
            var form = new frmServiceGallery(_selectedService);
            FormInit(form);
            await LoadPictures(new HairSalonServicePictureSearchRequest { HairSalonServiceId = _selectedService.HairSalonServiceId });
            
        }

        private void FormInit(Form form)
        {
            this.Hide();
            form.Closed += (s, args) => this.Show();
            form.ShowDialog();
        }
    }
}
