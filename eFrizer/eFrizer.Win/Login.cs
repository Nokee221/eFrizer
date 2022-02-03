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
    public partial class Login : Form
    {
        private readonly APIService _user = new APIService("Login");
        public Login()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {

            APIService.Username = txtUsername.Text;
            APIService.Password = txtPassword.Text;

            try
            {
                var result = await _user.Login<Model.Manager>(txtUsername.Text , txtPassword.Text);
                if(result.ApplicationUserRoles.Any(x => x.Role.Name == "Manager" || x.Role.Name == "Manager Employee"))
                {
                    this.Hide();
                    ManagerHome frmmanagerHome = new ManagerHome(result);
                    frmmanagerHome.Closed += (s, args) => this.Close();
                    frmmanagerHome.Show();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Pogrešan username ili password");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var forma = new Register();
            forma.ShowDialog();
        }
    }
}
