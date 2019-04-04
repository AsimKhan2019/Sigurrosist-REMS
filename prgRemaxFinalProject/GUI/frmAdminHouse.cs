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
    public partial class frmAdminHouse : Form
    {
        public frmAdminHouse()
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

        private void frmAdminHouse_Load(object sender, EventArgs e)
        {
            if (permission == 2)
            {
                current = new clsAgent();
                gridAll.DataSource = current.Searched_House_Belong_to_Current_Agent(RefAgent);
                gridAll.Focus();
            }
            else
            {
                admin = new clsAdmin();
                gridAll.DataSource = admin.Search_All_Houses();
            }
            gridAll.ReadOnly = true;
            ButtonControl(true, false, false, false, true, false);
            string[] access = { "Yes", "No" };
            string[] status = { "Sold", "Onsale" };
            cboAccess.DataSource = access;
            cboStatus.DataSource = status;
        }
        private void ButtonControl(bool add, bool edit, bool save, bool cancel, bool delete, bool txtboxes)
        {
            btnAdd.Visible = add;
            btnEdit.Visible = edit;
            btnSave.Visible = save;
            btnCancel.Visible = cancel;
            btnDelete.Visible = delete;
            txtAddress.Enabled = txtArea.Enabled = txtBath.Enabled = txtFloor.Enabled = 
                txtPrice.Enabled = txtRoom.Enabled = cboAccess.Enabled = cboStatus.Enabled
                = txtboxes;
        }
        private void gridAll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!txtAddress.Enabled)
            {
                ButtonControl(true, true, false, false, true, false);
                string houseid = gridAll.Rows[e.RowIndex].Cells[0].Value.ToString();
                clsAdmin admin = new clsAdmin();
                clsHouse house = new clsHouse();
                house = admin.Searched_by_RefHouse(Convert.ToInt32(houseid));
                txtAddress.Text = house.Address;
                txtArea.Text = house.Area.ToString();
                txtBath.Text = house.NumBath.ToString();
                txtFloor.Text = house.Floor.ToString();
                txtPrice.Text = house.Price.ToString();
                txtRoom.Text = house.NumRoom.ToString();
                if (house.Accessible)
                {
                    cboAccess.SelectedItem = "Yes";
                }
                else
                {
                    cboAccess.SelectedItem = "No";
                }
                cboStatus.Text = house.Status;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (permission == 2)
            {
                MessageBox.Show("To add a house, please confirm with an admin", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txtAddress.Clear();
                txtArea.Clear();
                txtBath.Clear();
                txtFloor.Clear();
                txtPrice.Clear();
                txtRoom.Clear();
                cboAccess.SelectedIndex = 0;
                cboStatus.SelectedIndex = 0;

                txtAddress.Focus();
                ButtonControl(false, false, true, true, false, true);
                Addmode = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtAddress.Focus();
            ButtonControl(false, false, true, true, false, true);
            Addmode = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsAdmin admin = new clsAdmin();
            clsHouse house = new clsHouse();
            house.Address = txtAddress.Text;
            house.Area = Convert.ToInt32(txtArea.Text);
            house.Price = Convert.ToDecimal(txtPrice.Text);
            house.Floor = Convert.ToInt32(txtFloor.Text);
            house.NumRoom = Convert.ToInt32(txtRoom.Text);
            house.NumBath = Convert.ToInt32(txtBath.Text);
            if (cboAccess.SelectedItem.ToString() == "Yes")
            {
                house.Accessible = true;
            }
            else
            {
                house.Accessible = false;
            }
            house.Status = cboStatus.Text;

            if (Addmode)
            {
                if (admin.Add_New_House(house))
                {
                    MessageBox.Show("New House on the Address : " + house.Address + " is successfully added", "New House Added");
                }
                else
                {
                    MessageBox.Show("The house of the Address " + house.Address + " is not added.", "Try Again");
                }
                admin.Refresh_Database();
            }
            else
            {
                house.RefHouse = (int)gridAll.Rows[gridAll.CurrentRow.Index].Cells[0].Value;
                
                if (admin.Edit_House(house))
                {
                    MessageBox.Show("House ID " + house.RefHouse + " is successfully modified", "House Modified");
                }
                else
                {
                    MessageBox.Show("House ID : " + house.RefHouse + " is not modified.", "Try Again");
                }
            }
            if (permission != 2)
                gridAll.DataSource = admin.Search_All_Houses();
            else
                gridAll.DataSource = current.Searched_House_Belong_to_Current_Agent(RefAgent);

            ButtonControl(true, true, false, false, true, false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You really want to delete this House?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int refhouse = (int)gridAll.Rows[gridAll.CurrentRow.Index].Cells[0].Value;

                if (admin.Delete_House(refhouse))
                {
                    MessageBox.Show("House ID" + refhouse + " is successfully Deleted", "House Deleted");
                }
                else
                {
                    MessageBox.Show("House ID " + refhouse + " is not deleted.", "Try Again");
                }
            }
            admin.Refresh_Database();
            gridAll.DataSource = admin.Search_All_Houses();
            ButtonControl(true, true, false, false, true, false);
        }
    }
}
