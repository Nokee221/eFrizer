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
    public partial class frmHairSalon : Form
    {
        private HairSalon _hairSalon { get; set; }

        public frmHairSalon(HairSalon hairSalon)
        {
            _hairSalon = hairSalon;
            InitializeComponent();
        }

        private async void frmHairSalon_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            await LoadBasicInfo();
        }

        private async Task LoadBasicInfo()
        {
            txtName.Text = _hairSalon.Name;
            txtAddress.Text = _hairSalon.Address;
            txtDescription.Text = _hairSalon.Description;
        }
    }
}
