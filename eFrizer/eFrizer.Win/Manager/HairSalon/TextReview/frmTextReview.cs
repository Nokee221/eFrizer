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

namespace eFrizer.Win.Manager.HairSalon.TextReview
{
    public partial class frmTextReview : Form
    {
        private readonly Model.HairSalon hairSalon;
        private readonly APIService _textReview = new APIService("TextReview");

        public frmTextReview(Model.HairSalon hairSalon)
        {
            InitializeComponent();
            this.hairSalon = hairSalon;
            dgvTextReview.AutoGenerateColumns = false;
        }

        private async void frmTextReview_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            await LoadTextReview();
        }

        private async Task LoadTextReview()
        {
            var request = new Model.TextReviewSearchRequest()
            {
                HairSalonId = hairSalon.HairSalonId
            };

            var result = await _textReview.Get<List<Model.TextReview>>(request);

            dgvTextReview.DataSource = result;
            await LoadData();
        }
    }
}
