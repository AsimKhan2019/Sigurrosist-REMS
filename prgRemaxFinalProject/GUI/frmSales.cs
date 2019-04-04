using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using prgRemaxFinalProject.Business;

namespace prgRemaxFinalProject.GUI
{
    public partial class frmSales : Form
    {
        public frmSales()
        {
            InitializeComponent();
        }
        int permission;
        int refAgent;
        clsAdmin admin;
        clsAgent current;
        bool Addmode;
        public int Permission
        {
            get
            {
                return permission;
            }

            set
            {
                permission = value;
            }
        }
        public int RefAgent
        {
            get
            {
                return refAgent;
            }

            set
            {
                refAgent = value;
            }
        }
        private void frmSales_Load(object sender, EventArgs e)
        {
            admin = new clsAdmin();
            DataTable temp = new DataTable();
            // fill cboHouse
            cboHouse.DisplayMember = "Address";
            cboHouse.ValueMember = "RefHouse";
            cboHouse.DataSource = admin.HouseListToDataTable(admin.Search_All_Houses());

            // fill cboClient
            cboClient.DisplayMember = "ClientName";
            cboClient.ValueMember = "RefClient";
            cboClient.DataSource = admin.ClientListToDataTable(admin.All_Client());

            // fill cboAgent
            cboAgent.DisplayMember = "AgentName";
            cboAgent.ValueMember = "RefAgent";
            cboAgent.DataSource = admin.AgentListToDataTable(admin.Search_All_Agents());

            if (permission != 2)
            {
                gridAll.DataSource = admin.All_Sales();
            }
            else
            {
                gridAll.DataSource = admin.Search_Sales_Belong_To_RefAgent(RefAgent);
            }
            gridAll.ReadOnly = true;
            ButtonControl(true, false, false, false, true, false);
        }
        private void ButtonControl(bool add, bool edit, bool save, bool cancel, bool delete, bool txtboxes)
        {
            btnAdd.Visible = add;
            btnEdit.Visible = edit;
            btnSave.Visible = save;
            btnCancel.Visible = cancel;
            btnDelete.Visible = delete;
            cboAgent.Enabled = cboClient.Enabled = cboHouse.Enabled = txtDescription.Enabled = DateSales.Enabled = txtboxes;
        }
        private void gridAll_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!txtDescription.Enabled)
            {
                try
                {
                    ButtonControl(true, true, false, false, true, false);
                    string salesid = gridAll.Rows[e.RowIndex].Cells[0].Value.ToString();
                    clsAdmin admin = new clsAdmin();
                    clsSales sales = new clsSales();
                    sales = admin.Search_Sales_by_RefSales(Convert.ToInt32(salesid));
                    cboAgent.SelectedValue = sales.RefAgent;
                    cboClient.SelectedValue = sales.RefClient;
                    cboHouse.SelectedValue = sales.RefHouse;
                    txtDescription.Text = sales.Description.ToString();
                    DateSales.Text = sales.SalesDate.ToString();
                }
                catch
                {
                    // not in the grid content
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (permission == 2)
            {
                MessageBox.Show("To add a Sales Record, please confirm with an admin", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txtDescription.Clear();
                cboAgent.Focus();
                ButtonControl(false, false, true, true, false, true);
                Addmode = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cboAgent.Focus();
            ButtonControl(false, false, true, true, false, true);
            Addmode = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsAdmin admin = new clsAdmin();
            clsSales sales = new clsSales();
            sales.RefAgent = Convert.ToInt32(cboAgent.SelectedValue);
            sales.RefClient = Convert.ToInt32(cboClient.SelectedValue);
            sales.RefHouse = Convert.ToInt32(cboHouse.SelectedValue);
            sales.Description = txtDescription.Text;
            sales.SalesDate = DateTime.Parse(DateSales.Text);
            
            if (Addmode)
            {
                if (admin.Add_Sales(sales))
                {
                    MessageBox.Show("New Sales Record is successfully added", "New Sales Added");
                }
                else
                {
                    MessageBox.Show("The Sales Record is not added.", "Try Again");
                }
                admin.Refresh_Database();
            }
            else
            {
                sales.RefSales = (int)gridAll.Rows[gridAll.CurrentRow.Index].Cells[0].Value;

                if (admin.Edit_Sales(sales))
                {
                    MessageBox.Show("New Sales Record ID " + sales.RefSales + " is successfully modified", "Sales Modified");
                }
                else
                {
                    MessageBox.Show("The Sales Record " + sales.RefSales + " is not modified.", "Try Again");
                }
            }
            if (permission != 2)
                gridAll.DataSource = admin.All_Sales();
            else
                gridAll.DataSource = admin.Search_Sales_Belong_To_RefAgent(RefAgent);

            ButtonControl(true, true, false, false, true, false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You really want to delete this Sales Record?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int refsales = (int)gridAll.Rows[gridAll.CurrentRow.Index].Cells[0].Value;

                if (admin.Delete_Sales(refsales))
                {
                    MessageBox.Show("Sales Record ID" + refsales + " is successfully Deleted", "Sales Deleted");
                }
                else
                {
                    MessageBox.Show("Sales Record ID " + refsales + " is not deleted.", "Try Again");
                }
            }
            admin.Refresh_Database();
            if (permission != 2)
                gridAll.DataSource = admin.All_Sales();
            else
                gridAll.DataSource = admin.Search_Sales_Belong_To_RefAgent(RefAgent);
            ButtonControl(true, true, false, false, true, false);
        }
    }
}
