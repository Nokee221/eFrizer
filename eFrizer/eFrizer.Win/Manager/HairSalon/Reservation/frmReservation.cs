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
        private APIService _hairDresser = new APIService("HairDresser");
        private APIService _reservation = new APIService("Reservation");
        public frmReservation(HairSalon hairSalon)
        {
            InitializeComponent();
            _hairSalon = hairSalon;
            dgvReservation.AutoGenerateColumns = false;
        }

        private async void frmReservation_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            await LoadHairDresser();
            await LoadReservation();
        }

        private async Task LoadReservation()
        {
            var reservationSearch = new ReservationSearchRequest
            {
                HairSalonId = _hairSalon.HairSalonId
            };

            var result = await _reservation.Get<List<Model.Reservation>>(reservationSearch);
            dgvReservation.DataSource = result;
        }



        private async Task LoadHairDresser()
        {
            var request = new HairDresserSearchRequest();
            request.HairSalonId = _hairSalon.HairSalonId;

            var result = await _hairDresser.Get<List<HairDresser>>(request);

            cbHDName.DataSource = result;
            cbHDName.DisplayMember = "Name";
            cbHDName.ValueMember = "ApplicationUserId";

        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            
            var request = new ReservationSearchRequest();
            request.HairDresserId = Convert.ToInt32(cbHDName.SelectedValue);
            request.Day = dtpDate.Value.Day;
            request.Month = dtpDate.Value.Month;

            var result = await _reservation.Get<List<Model.Reservation>>(request);
            dgvReservation.DataSource = result;
        }
    }
}
