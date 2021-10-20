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
        private readonly HairSalon _hairSalon;
        private APIService _hairDresserService = new APIService("HairDresser");
        private APIService _hairSalonHairDresserService = new APIService("HairSalonHairDresser");

        public frmHairDresserManager(HairSalon hairSalon, HairDresser hairDresser = null)
        {
            _hairSalon = hairSalon;
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
            txtName.Text = _hairDresser?.Name;
            txtSurname.Text = _hairDresser?.Surname;
            txtDescription.Text = _hairDresser?.Description;
            //TODO: get image&status
            //pbHairDresser.Image = _hairDresser.Image;
            //cbStatus.Checked = _hairDresser.Status;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if(_hairDresser == null)
            {
                var req = new HairDresserInsertRequest()
                {
                    Name = txtName.Text,
                    Surname = txtSurname.Text,
                    Description = txtSurname.Text,
                    Username = "Hair Dresser " + DateTime.Now,
                    Password = "1234",
                    PasswordConfirmation = "1234"

                };

                _hairDresser = await _hairDresserService.Insert<HairDresser>(req);
                await _hairSalonHairDresserService.Insert<HairSalonHairDresser>(new HairSalonHairDresser()
                {
                    HairDresserId = _hairDresser.ApplicationUserId,
                    HairSalonId = _hairSalon.HairSalonId
                });
                MessageBox.Show("Successfully added new hair dresser!");
                Close();
            }
            else
            {
                var req = new HairDresserUpdateRequest()
                {
                    Name = txtName.Text,
                    Surname = txtSurname.Text,
                    Description = txtDescription.Text
                };
                _hairDresser = await _hairDresserService.Update<HairDresser>(_hairDresser.ApplicationUserId, req);
                MessageBox.Show("Successfully updated the hair dresser!");
                Close();
            }
        }
    }
}
