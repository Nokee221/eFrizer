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

namespace eFrizer.Win.Reservation
{
    public partial class frmReservation : Form
    {

        private readonly HairSalon _hairSalon;
        private APIService _hairsalonhairdresser = new APIService("HairSalonHairDresser");
        public frmReservation(HairSalon hairSalon)
        {
            InitializeComponent();
            _hairSalon = hairSalon;
        }

        private async void frmReservation_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            await LoadHairDresser();
        }

        private async Task LoadHairDresser()
        {
            var request = new HairSalonHairDresserSearchRequest();
            request.HairSalonId = _hairSalon.HairSalonId;

            var result = await _hairsalonhairdresser.Get<List<HairSalonHairDresser>>(request);
            dgvReservation.DataSource = result;

           
        }
    }
}
