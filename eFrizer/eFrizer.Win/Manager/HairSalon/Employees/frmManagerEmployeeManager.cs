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
    public partial class frmManagerEmployeeManager : Form
    {
        private Manager _managerEmployee;
        private readonly HairSalon _hairSalon;
        private APIService _managerService = new APIService("Manager");
        private APIService _hairSalonManagerService = new APIService("HairSalonManager");

        public frmManagerEmployeeManager(HairSalon hairSalon, Manager manager = null)
        {
            _hairSalon = hairSalon;
            _managerEmployee = manager;
            InitializeComponent();
        }

        private void frmManagerEmployeeManager_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            LoadBasicInfo();
        }

        private void LoadBasicInfo()
        {
            txtName.Text = _managerEmployee?.Name;
            txtSurname.Text = _managerEmployee?.Surname;
            txtDescription.Text = _managerEmployee?.Description;
            cbStatus.Checked = _managerEmployee == null ? false : _managerEmployee.Status;
            //TODO: get image&status
            //pbHairDresser.Image = _hairDresser.Image;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_managerEmployee == null)
            {
                var req = new ManagerInsertRequest()
                {
                    Name = txtName.Text,
                    Surname = txtSurname.Text,
                    Description = txtSurname.Text,
                    Username = "Hair Manager " + DateTime.Now,
                    Password = "1234",
                    PasswordConfirmation = "1234",
                    Status = cbStatus.Checked

                };

                _managerEmployee = await _managerService.Insert<Manager>(req);
                await _hairSalonManagerService.Insert<HairSalonManager>(new HairSalonManagerInsertRequest()
                {
                    ManagerId = _managerEmployee.ApplicationUserId,
                    HairSalonId = _hairSalon.HairSalonId
                });
                MessageBox.Show("Successfully added new manager employee!");
                Close();
            }
            else
            {
                var req = new ManagerUpdateRequest()
                {
                    Name = txtName.Text,
                    Surname = txtSurname.Text,
                    Description = txtDescription.Text,
                    Status = cbStatus.Checked
                };
                _managerEmployee = await _managerService.Update<Manager>(_managerEmployee.ApplicationUserId, req);
                MessageBox.Show("Successfully updated the manager employee!");
                Close();
            }
        }

        
    }
}
