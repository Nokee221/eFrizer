using DoddleReport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eFrizer.Win
{
    public partial class ReservationReport : Form
    {
        private APIService _reservations = new APIService("Reservation");
        private Report reservationReport;

        public ReservationReport()
        {
            InitializeComponent();
        }

        private async void ReservationReport_Load(object sender, EventArgs e)
        {
            var reservations = await GetReservations();
            reservationReport = new Report(reservations.ToReportSource(), new DoddleReport.iTextSharp.PdfReportWriter());

            reservationReport.TextFields.Title = "Reservation Report";
            reservationReport.TextFields.SubTitle = "Financial reports of hair salon";
            reservationReport.TextFields.Footer = "Copyright 2021 &copy; Kenan&Amar";
            reservationReport.TextFields.Header = string.Format(@"
            Report Generated: {0}
            Total Reservations: {1}
            ", DateTime.Now, reservations.Count());
            
        }

        public async Task<List<Model.Reservation>> GetReservations()
        {
            var reservations = await _reservations.Get<List<Model.Reservation>>();
            return reservations;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            using(var stream = File.Create("ReservationReport.pdf"))
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
    }
}
