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

namespace eFrizer.Win
{
    public partial class ManagerHome : Form
    {
        private readonly APIService _hairSalons = new APIService("HairSalon");

        public ManagerHome()
        {
            InitializeComponent();
        }

        private async Task LoadData()
        {
            //await LoadManager();
            APIService.Username = "auser";
            APIService.Password = "1234";
            await LoadHairSalons();
        }

        private async Task LoadHairSalons()
        {
            var result = await _hairSalons.Get<List<HairSalon>>(null);
            dgvManagerHome.DataSource = result;
        }

        private async void ManagerHome_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        //private Task LoadManager()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
