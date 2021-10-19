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

namespace eFrizer.Win.Categories
{
    public partial class frmCategories : Form
    {

        private readonly HairSalon _hairSalon;
        private APIService _categories = new APIService("HairSalonType");
        private APIService _hairsalonCategories = new APIService("HairSalonHairSalonType");
        public frmCategories(HairSalon hairSalon = null)
        {
            InitializeComponent();
            _hairSalon = hairSalon;
            dgvCategories.AutoGenerateColumns = false;
        }

        private async void frmCategories_Load(object sender, EventArgs e)
        {
            await LoadData();
            
        }

        private async Task LoadData()
        {
            await LoadCategories();
            await LoadDataSourceCategories();
        }

        private async Task LoadDataSourceCategories()
        {
            var request = new HairSalonHairSalonTypeSearchRequest();
            request.HairSalonId = _hairSalon.HairSalonId;

            var result = await _hairsalonCategories.Get<List<HairSalonHairSalonType>>(request);
            dgvCategories.DataSource = result;

        }

        private async Task LoadCategories()
        {
            var categories = await _categories.Get<List<HairSalonType>>();
            cbCategories.DataSource = categories;
            cbCategories.DisplayMember = "Name";
            cbCategories.ValueMember = "HairSalonTypeId";
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtName.Text))
            {
                var catName = txtName.Text;

                var request = new HairSalonHairSalonTypeInsertRequest();
                request.Name = catName;
                request.HairSalonId = _hairSalon.HairSalonId;

                var result = await _hairsalonCategories.Insert<HairSalonHairSalonType>(request);
            }
            else
            {
                var request = new HairSalonHairSalonTypeInsertRequest();
                request.Name = cbCategories.Text;
                request.HairSalonId = _hairSalon.HairSalonId;

                var result = await _hairsalonCategories.Insert<HairSalonHairSalonType>(request);

            }


            await LoadData();
        }
    }
}
