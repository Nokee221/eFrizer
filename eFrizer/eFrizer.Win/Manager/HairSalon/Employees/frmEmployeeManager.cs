using eFrizer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        private List<HairSalonHairDresser> _hairSalonHairDressers;
        private List<HairSalonManager> _hairSalonManagers;

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
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            cbType.DataSource = new List<string>()
            {
                "Any",
                "Hair Dressers",
                "Managers"
            };

            cbStatus.DataSource = new List<string>()
            {
                "Any",
                "Active",
                "Inactive"
            };
        }

        private async Task LoadEmployeeList()
        {
            var reqHD = new HairSalonHairDresserSearchRequest() { HairSalonId = _hairSalon.HairSalonId};
            var reqM = new HairSalonManagerSearchRequest() { HairSalonId = _hairSalon.HairSalonId};

            _hairSalonHairDressers = await _hairDressers.Get<List<HairSalonHairDresser>>(reqHD);
            //TODO: Will excluding the user on the db side improve query performance?
            _hairSalonManagers = await _managers.Get<List<HairSalonManager>>(reqM);

            dgvEmployees.AutoGenerateColumns = false;
            populate_dgvEmployees(_hairSalonHairDressers, _hairSalonManagers);
        }

        private void populate_dgvEmployees(List<HairSalonHairDresser> hairDressers = null, List<HairSalonManager> managers = null)
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

            if (hairDressers != null)
            {
                foreach (var item in hairDressers)
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
            }

            if (managers != null)
            {
                foreach (var item in managers)
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
            }

            dgvEmployees.DataSource = dataTable;
            dgvEmployees.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEmployees.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private async void dgvEmployees_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dresser = _hairSalonHairDressers.Where(x => x.HairDresserId == Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells[0].Value)).FirstOrDefault();
            var manager = _hairSalonManagers.Where(x => x.ManagerId == Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells[0].Value)).FirstOrDefault();

            if (manager == null)
            {
                var form = new frmHairDresserManager(_hairSalon, dresser.HairDresser).ShowDialog();
            }
            else if (dresser == null)
            {
                var form = new frmManagerEmployeeManager(_hairSalon, manager.Manager).ShowDialog();
            }

            await LoadData();
        }

        private async void btnAddHairDresser_Click(object sender, EventArgs e)
        {
            new frmHairDresserManager(_hairSalon).ShowDialog();
            await LoadData();
        }

        private async void btnAddManager_Click(object sender, EventArgs e)
        {
            new frmManagerEmployeeManager(_hairSalon).ShowDialog();
            await LoadData();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if(txtName.Text != "")
            {
                var hairSalonHairDressers = _hairSalonHairDressers.Where(x => x.HairDresser.Name.Contains(txtName.Text) || x.HairDresser.Surname.Contains(txtName.Text)).ToList();
                var hairSalonManagers = _hairSalonManagers.Where(x => x.Manager.Name.Contains(txtName.Text) || x.Manager.Surname.Contains(txtName.Text)).ToList();
                populate_dgvEmployees(hairSalonHairDressers, hairSalonManagers);
            }
            else
            {
                populate_dgvEmployees(_hairSalonHairDressers, _hairSalonManagers);
            }
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if((string)cbType.SelectedValue == "Hair Dressers")
            {
                populate_dgvEmployees(_hairSalonHairDressers, null);
            }
            else if((string)cbType.SelectedValue == "Managers")
            {
                populate_dgvEmployees(null, _hairSalonManagers);
            }
            else
            {
                populate_dgvEmployees(_hairSalonHairDressers, _hairSalonManagers);
            }
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)cbStatus.SelectedValue == "Active")
            {
                var managers = _hairSalonManagers.Where(x => x.Manager.Status == true).ToList();
                var hairDressers = _hairSalonHairDressers.Where(x => x.HairDresser.Status == true).ToList();
                populate_dgvEmployees(hairDressers, managers);
            }
            else if ((string)cbStatus.SelectedValue == "Inactive")
            {
                var managers = _hairSalonManagers.Where(x => x.Manager.Status == false).ToList();
                var hairDressers = _hairSalonHairDressers.Where(x => x.HairDresser.Status == false).ToList();
                populate_dgvEmployees(hairDressers, managers);
            }
            else
            {
                populate_dgvEmployees(_hairSalonHairDressers, _hairSalonManagers);
            }
        }
    }
}
