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
    public partial class frmHairDresserManager : Form
    {
        private HairDresser _hairDresser;

        public frmHairDresserManager(HairDresser hairDresser)
        {
            _hairDresser = hairDresser;
            InitializeComponent();
        }

        private void frmHairDresserManager_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            LoadBasicInfo();
        }

        private void LoadBasicInfo()
        {
            txtName.Text = _hairDresser.Name;
            txtSurname.Text = _hairDresser.Surname;
            txtDescription.Text = _hairDresser.Description;
            //TODO: get image&status
            //pbHairDresser.Image = _hairDresser.Image;
            //cbStatus.Checked = _hairDresser.Status;
        }
    }
}
