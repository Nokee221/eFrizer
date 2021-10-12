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
    public partial class Register : Form
    {

        APIService korisniciServis = new APIService("Register");
        APIService rolesService = new APIService("Role");
        public Register()
        {
            InitializeComponent();
        }

         private void Register_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            
            ApplicationUserInsertRequest request = new ApplicationUserInsertRequest()
            {
                Name = txtName.Text,
                Surname = txtSurname.Text,
                Username = txtUserName.Text,
                Password = txtPassword.Text,
                PasswordConfirmation = txtConfirmitivePass.Text,
                Status = true,

            };

            var user = await korisniciServis.Register<ApplicationUser>(request);


            ManagerHome managerHome = new ManagerHome(user);
            managerHome.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        
    }
}
