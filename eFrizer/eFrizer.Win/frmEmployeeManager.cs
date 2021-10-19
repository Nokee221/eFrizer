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
    public partial class frmEmployeeManager : Form
    {
        //TODO: Should these services be actually querying an Employees table?
        //Or maybe should I make a controller that returns the Employees with a given Hair Salon Id?
        private Manager _managerOwner;
        private HairSalon _hairSalon;
        private APIService _hairDressers = new APIService("HairSalonHairDresser");
        private APIService _managers = new APIService("HairSalonManager");
        private List<HairSalonHairDresser> hairSalonHairDressers;
        private List<HairSalonManager> hairSalonManagers;

        public frmEmployeeManager(HairSalon hairSalon, Manager user)
        {
            _hairSalon = hairSalon;
            _managerOwner = user;
            InitializeComponent();
        }

        private async void frmEmployeeManager_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            await LoadEmployeeList();
        }

        private async Task LoadEmployeeList()
        {
            var reqHD = new HairSalonHairDresserSearchRequest() { HairSalonId = _hairSalon.HairSalonId};
            var reqM = new HairSalonManagerSearchRequest() { HairSalonId = _hairSalon.HairSalonId};

            hairSalonHairDressers = await _hairDressers.Get<List<HairSalonHairDresser>>(reqHD);
            //TODO: Will excluding the user on the db side improve query performance?
            hairSalonManagers = await _managers.Get<List<HairSalonManager>>(reqM);

            dgvEmployees.AutoGenerateColumns = false;
            populate_dgvEmployees();
        }

        private void populate_dgvEmployees()
        {
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("ApplicationUserId"),
                new DataColumn("Name"),
                new DataColumn("Surname"),
                new DataColumn("Description"),
                new DataColumn("Type"),
                new DataColumn("Status"),
            });

            foreach (var item in hairSalonHairDressers)
            {
                var row = dataTable.NewRow();
                row["ApplicationUserId"] = item.HairDresserId; 
                row["Name"] = item.HairDresser.Name;
                row["Surname"] = item.HairDresser.Surname;
                row["Description"] = item.HairDresser.Description;
                row["Type"] = item.HairDresser.Type;
                //row["Status"] = item.Status,
                dataTable.Rows.Add(row);
            }

            foreach (var item in hairSalonManagers)
            {
                if (item.Manager.ApplicationUserId == _managerOwner.ApplicationUserId)
                    continue;
                var row = dataTable.NewRow();
                row["ApplicationUserId"] = item.Manager.ApplicationUserId;
                row["Name"] = item.Manager.Name;
                row["Surname"] = item.Manager.Surname;
                row["Description"] = item.Manager.Description;
                //TODO: is there a better way than hardcoding this? how to use the type defined in model?
                row["Type"] = "Manager Employee";
                //row["Status"] = item.Status,
                dataTable.Rows.Add(row);
            }

            dgvEmployees.DataSource = dataTable;
            dgvEmployees.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEmployees.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private async void dgvEmployees_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dresser = hairSalonHairDressers.Where(x => x.HairDresserId == Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells[0].Value)).FirstOrDefault();
            var manager = hairSalonManagers.Where(x => x.ManagerId == Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells[0].Value)).FirstOrDefault();

            if (manager == null)
            {
                var form = new frmHairDresserManager(_hairSalon, dresser.HairDresser).ShowDialog();
            }
            else if (dresser == null)
            {
                var form = new frmManagerEmployeeManager(manager.Manager).ShowDialog();
            }

            await LoadData();
        }

        private void btnAddHairDresser_Click(object sender, EventArgs e)
        {
            new frmHairDresserManager(_hairSalon).ShowDialog();
        }
    }
}
