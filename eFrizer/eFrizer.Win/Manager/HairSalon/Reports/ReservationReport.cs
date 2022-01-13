using DoddleReport;
using eFrizer.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eFrizer.Win
{
    public partial class ReservationReport : Form
    {
        private APIService _reservations = new APIService("Reservation");
        private List<Model.Reservation> reservationData { get; set; }
        private Report reservationReport;


        public ReservationReport()
        {
            InitializeComponent();
        }

        class ReservationData
        {
            public string Client { get; set; }
            public string HairDresser { get; set; }
            public string Service { get; set; }
            public float Price { get; set; }
        }

        private async void ReservationReport_Load(object sender, EventArgs e)
        {
            reservationData = await GetReservations();
        }

        public async Task<List<Model.Reservation>> GetReservations()
        {
            var reservationSearchRequest = new ReservationSearchRequest()
            {
                From = dtpFrom.Value,
                To = dtpTo.Value
            };
            var reservations = await _reservations.Get<List<Model.Reservation>>(reservationSearchRequest);
            return reservations;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            var data = reservationData.Select(x =>
            new ReservationData
            {
                Client = x.Client.Name,
                HairDresser = x.HairDresser.Name,
                Service = x.ServiceName,
                Price = x.HairSalonService.Price
            });
            
            float sum = 0.0f;
            foreach (var item in data)
            {
                sum += item.Price;
            }


            reservationReport = new Report(data.ToReportSource(), new DoddleReport.iTextSharp.PdfReportWriter());

            reservationReport.TextFields.Title = "Financial report for <HairSalonName>";//TODO: reference the current hair salon
            reservationReport.TextFields.SubTitle = "The report is based on data from the last 5 days.";
            reservationReport.TextFields.SubTitle = string.Format(@"Sum of column 'Price': {0}", sum);
            reservationReport.TextFields.Footer = "Copyright 2021 &copy; Kenan&Amar";
            reservationReport.TextFields.Header = string.Format(@"
            Report Generated: {0}
            Total Reservations: {1}
            ", DateTime.Now, data.Count());

            using (var stream = File.Create("ReservationReport.pdf"))
            {
                reservationReport.WriteReport(stream);
            }

            var p = new Process();
            p.StartInfo = new ProcessStartInfo("ReservationReport.pdf")
            {
                UseShellExecute = true
            };
            p.Start();

        }

        private async void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            reservationData = await GetReservations();
        }

        private async void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            reservationData = await GetReservations();
        }
    }
}
