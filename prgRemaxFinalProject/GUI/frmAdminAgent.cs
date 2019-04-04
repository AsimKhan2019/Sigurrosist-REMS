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
    public partial class frmAdminAgent : Form
    {
        public frmAdminAgent()
        {
            InitializeComponent();
        }
        clsAdmin admin;
        bool Addmode;

        private void frmAdminAgent_Load(object sender, EventArgs e)
        {
            admin = new clsAdmin();
            gridAll.DataSource = admin.Search_All_Agents();
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
            txtID.Enabled = txtName.Enabled = txtPhone.Enabled = txtSalesPoint.Enabled = txtClient.Enabled = txtboxes;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ButtonControl(false, false, true, true, false, true);
            txtID.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtClient.Clear();
            txtSalesPoint.Clear();
            txtID.Focus();
            Addmode = true;
        }

        private void gridAll_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!txtID.Enabled)
            {
                ButtonControl(true, true, false, false, true, false);
                string selecteduserid = gridAll.Rows[e.RowIndex].Cells[1].Value.ToString();
                clsAgent selecteduser = new clsAgent();
                selecteduser = selecteduser.Current_User(selecteduserid);
                txtID.Text = selecteduser.UserID;
                txtName.Text = selecteduser.Name;
                txtPhone.Text = selecteduser.PhoneNumber;
                txtSalesPoint.Text = selecteduser.SalesPoint.ToString();
                txtClient.Text = selecteduser.RefClient.ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ButtonControl(false, false, true, true, false, true);
            txtID.Focus();
            Addmode = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsAdmin adminagent = new clsAdmin();
            clsAgent temp = new clsAgent();
            temp.UserID = txtID.Text.Trim();
            temp.Name = txtName.Text.Trim();
            temp.PhoneNumber = txtPhone.Text.Trim();
            temp.SalesPoint = Convert.ToInt32(txtSalesPoint.Text);
            temp.RefClient = Convert.ToInt32(txtClient.Text);
            if(Addmode)
            {
                if (adminagent.Add_New_Agent(temp))
                {
                    MessageBox.Show("New Agent " + temp.Name + " is successfully added", "New Agent");
                }
                else
                {
                    MessageBox.Show("Agent " + temp.Name + " is not added.", "Try Again");
                }
                admin.Refresh_Database();
            }
            else
            {
                temp.RefAgent = (int)gridAll.Rows[gridAll.CurrentRow.Index].Cells[0].Value;
                if (adminagent.Edit_Agent(temp))
                {
                    MessageBox.Show("Agent " + temp.Name + " is successfully modified", "Agent Modified");
                }
                else
                {
                    MessageBox.Show("Agent " + temp.Name + " is not edited.", "Try Again");
                }
            }
            gridAll.DataSource = admin.Search_All_Agents();
            ButtonControl(true, true, false, false, true, false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ButtonControl(true, true, false, false, true, false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You really want to delete this Agent?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int refagent = (int)gridAll.Rows[gridAll.CurrentRow.Index].Cells[0].Value;

                if (admin.Delete_Agent(refagent))
                {
                    MessageBox.Show("Agent ID" + refagent + " is successfully Deleted", "Agent Deleted");
                }
                else
                {
                    MessageBox.Show("Agent " + refagent + " is not deleted.", "Try Again");
                }
            }
            gridAll.DataSource = admin.Search_All_Agents();
            ButtonControl(true, true, false, false, true, false);
        }
    }
}
