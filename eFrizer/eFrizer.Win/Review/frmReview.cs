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

namespace eFrizer.Win.Review
{
    public partial class frmReview : Form
    {
        private readonly HairSalon _hairSalon;
        private readonly APIService _review = new APIService("Review");
        public frmReview(HairSalon hairSalon)
        {
            _hairSalon = hairSalon;
            InitializeComponent();
            dgvReview.AutoGenerateColumns = false;
        }

        private async void frmReview_Load(object sender, EventArgs e)
        {
            await LoadData();
            
        }

        private async Task LoadData()
        {
            await LoadReview();
        }

        private async Task LoadReview()
        {
            var request = new ReviewSearchRequest()
            {
                HairSalonId = _hairSalon.HairSalonId
            };

            var result = await _review.Get<List<Model.Review>>(request);

            dgvReview.DataSource = result;
            await LoadData();
        }
    }
}
