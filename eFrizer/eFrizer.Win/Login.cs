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
                var result = await _user.Login<ApplicationUser>(txtUsername.Text , txtPassword.Text);
                MessageBox.Show("fala kurcu");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Pogrešan username ili password");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
