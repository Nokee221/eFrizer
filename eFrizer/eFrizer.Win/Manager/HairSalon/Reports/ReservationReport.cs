using DoddleReport;
using eFrizer.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
        private HairSalon _hairSalon;
        public ReservationSearchRequest reservationSearch { get; set; }


        public ReservationReport(HairSalon hairSalon)
        {
            _hairSalon = hairSalon;
            InitializeComponent();
        }

        class ReservationData
        {
            public string Client { get; set; }
            public string HairDresser { get; set; }
            public string Service { get; set; }
            public string From { get; set; }
            public string To { get; set; }
        }

        class FinancialData
        {
            public string HairDresser { get; set; }
            public string Service { get; set; }
            public float Price { get; set; }
        }

        class ServiceData
        {
            public string Service { get; set; }
            public string From { get; set; }
            public string To { get; set; }
        }

        private async void ReservationReport_Load(object sender, EventArgs e)
        {
            reservationData = await GetReservations();
        }

        public async Task<List<Model.Reservation>> GetReservations(DateTime? from = null, DateTime? to = null)
        {
            reservationSearch = new ReservationSearchRequest()
            {
                HairSalonId = _hairSalon.HairSalonId,
                From = from,
                To = to
            };
            var reservations = await _reservations.Get<List<Model.Reservation>>(reservationSearch);
            return reservations;
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            var data = reservationData.Select(x =>
            new ReservationData
            {
                Client = x.Client.Name,
                HairDresser = x.HairDresser.Name,
                Service = x.ServiceName,
                From = x.From.ToShortDateString() + " " + x.From.ToShortTimeString(),
                To = x.To.ToShortDateString() + " " + x.To.ToShortTimeString()
            });
            
            reservationReport = new Report(data.ToReportSource(), new DoddleReport.iTextSharp.PdfReportWriter());

            reservationReport.TextFields.Title = string.Format(@"Reservation report for {0}", _hairSalon.Name);
            reservationReport.TextFields.Footer = string.Format(@"Data displayed from: {0} until {1}", dtpReservationFrom.Value.ToShortDateString(), dtpReservationTo.Value.ToShortDateString());
            
            for (int i = 0; i < reservationReport.DataFields.Count; i++)
            {
                reservationReport.DataFields[i].HeaderStyle.BackColor = Color.Black;
                reservationReport.DataFields[i].HeaderStyle.ForeColor = Color.White;
                reservationReport.DataFields[i].DataStyle.BackColor = Color.White;
                reservationReport.DataFields[i].DataStyle.ForeColor = Color.Black;
                reservationReport.DataFields[i].DataStyle.Underline = true;
                reservationReport.DataFields[i].ShowTotals = true;
            }
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

        private async void dtpReservationFrom_ValueChanged(object sender, EventArgs e)
        {
            reservationData = await GetReservations(dtpReservationFrom.Value, dtpReservationTo.Value);
        }

        private async void dtpReservationTo_ValueChanged(object sender, EventArgs e)
        {
            reservationData = await GetReservations(dtpReservationFrom.Value, dtpReservationTo.Value);
        }

        private void btnFinancial_Click(object sender, EventArgs e)
        {
            var data = reservationData.Select(x =>
            new FinancialData
            {
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

            reservationReport.TextFields.Title = string.Format(@"Financial report for {0}", _hairSalon.Name);
            reservationReport.TextFields.SubTitle = string.Format(@"Turnover: {0}$", sum);
            reservationReport.TextFields.Footer = string.Format(@"Data displayed from: {0} until {1}", dtpReservationFrom.Value.ToShortDateString(), dtpReservationTo.Value.ToShortDateString());
            

            for (int i = 0; i < reservationReport.DataFields.Count; i++)
            {
                reservationReport.DataFields[i].HeaderStyle.BackColor = Color.Black;
                reservationReport.DataFields[i].HeaderStyle.ForeColor = Color.White;
                reservationReport.DataFields[i].DataStyle.BackColor = Color.White;
                reservationReport.DataFields[i].DataStyle.ForeColor = Color.Black;
                reservationReport.DataFields[i].DataStyle.Underline = true;
                
            }
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

        private async void dtpFinancialFrom_ValueChanged(object sender, EventArgs e)
        {
            reservationData = await GetReservations(dtpFinancialFrom.Value, dtpFinancialTo.Value);
        }

        private async void dtpFinancialTo_ValueChanged(object sender, EventArgs e)
        {
            reservationData = await GetReservations(dtpFinancialFrom.Value, dtpFinancialTo.Value);
        }

        private void btnServiceReport_Click(object sender, EventArgs e)
        {
            var data = reservationData.Select(x =>
            new ServiceData
            {
                Service = x.ServiceName,
                From = x.From.ToShortDateString() + " " + x.From.ToShortTimeString(),
                To = x.To.ToShortDateString() + " " + x.To.ToShortTimeString()
            }); 

            reservationReport = new Report(data.ToReportSource(), new DoddleReport.iTextSharp.PdfReportWriter());

            reservationReport.TextFields.Title = string.Format(@"Service report for {0}", _hairSalon.Name);
            reservationReport.TextFields.Footer = string.Format(@"Data displayed from: {0} until {1}", dtpReservationFrom.Value.ToShortDateString(), dtpReservationTo.Value.ToShortDateString());
            

            for (int i = 0; i < reservationReport.DataFields.Count; i++)
            {
                reservationReport.DataFields[i].HeaderStyle.BackColor = Color.Black;
                reservationReport.DataFields[i].HeaderStyle.ForeColor = Color.White;
                reservationReport.DataFields[i].DataStyle.BackColor = Color.White;
                reservationReport.DataFields[i].DataStyle.ForeColor = Color.Black;
                reservationReport.DataFields[i].DataStyle.Underline = true;
            }
            reservationReport.TextFields.Header = string.Format(@"
            Report Generated: {0}
            Total Reservations: {1}
            ", DateTime.Now, data.Count());

            using (var stream = File.Create("ServiceReport.pdf"))
            {
                reservationReport.WriteReport(stream);
            }

            var p = new Process();
            p.StartInfo = new ProcessStartInfo("ServiceReport.pdf")
            {
                UseShellExecute = true
            };
            p.Start();
        }

        private async void dtpServiceFrom_ValueChanged(object sender, EventArgs e)
        {
            reservationData = await GetReservations(dtpServiceFrom.Value, dtpServiceTo.Value);
        }

        private async void dtpServiceTo_ValueChanged(object sender, EventArgs e)
        {
            reservationData = await GetReservations(dtpServiceFrom.Value, dtpServiceTo.Value);
        }

        
    }
}
