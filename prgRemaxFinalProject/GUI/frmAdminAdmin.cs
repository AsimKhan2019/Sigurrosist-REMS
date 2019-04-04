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
    public partial class frmAdminAdmin : Form
    {
        public frmAdminAdmin()
        {
            InitializeComponent();
        }
        clsAdmin admin;
        bool Addmode;
        private void frmAdminAdmin_Load(object sender, EventArgs e)
        {
            admin = new clsAdmin();
            gridAll.DataSource = admin.Search_All_Admins();
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
            txtID.Enabled = txtName.Enabled = txtPhone.Enabled = txtboxes;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ButtonControl(false, false, true, true, false, true);
            txtID.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtID.Focus();
            Addmode = true;
        }


        private void gridAll_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!txtID.Enabled)
            {
                ButtonControl(true, true, false, false, true, false);
                string selecteduserid = gridAll.Rows[e.RowIndex].Cells[1].Value.ToString();
                clsAdmin selecteduser = admin.Current_User(selecteduserid);
                txtID.Text = selecteduser.UserID;
                txtName.Text = selecteduser.Name;
                txtPhone.Text = selecteduser.PhoneNumber;
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
            clsAdmin temp = new clsAdmin();
            temp.UserID = txtID.Text.Trim();
            temp.Name = txtName.Text.Trim();
            temp.PhoneNumber = txtPhone.Text.Trim();

            if (Addmode)
            {                    
                if(temp.Add_New_Admin(temp))
                {
                    MessageBox.Show("New Administrator " + temp.Name + " is successfully added", "New Admin");
                }
                else
                {
                    MessageBox.Show("Administrator " + temp.Name + " is not added.", "Try Again");
                }
                admin.Refresh_Database();
            }

            else
            {
                temp.RefAdmin = (int)gridAll.Rows[gridAll.CurrentRow.Index].Cells[0].Value;
                if (temp.Edit_Admin(temp))
                {
                    MessageBox.Show("Administrator " + temp.Name + " is successfully modified", "Admin Modified");
                }
                else
                {
                    MessageBox.Show("Administrator " + temp.Name + " is not edited.", "Try Again");
                }
            }
            gridAll.DataSource = admin.Search_All_Admins();
            ButtonControl(true, true, false, false, true, false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ButtonControl(true, true, false, false, true, false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do You really want to delete this Administrator?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int refadmin = (int)gridAll.Rows[gridAll.CurrentRow.Index].Cells[0].Value;

                if(admin.Delete_Admin(refadmin))
                {
                    MessageBox.Show("Admin ID" + refadmin + " is successfully Deleted", "Admin Deleted");
                }
                else
                {
                    MessageBox.Show("Administrator " + refadmin + " is not deleted.", "Try Again");
                }
            }
            gridAll.DataSource = admin.Search_All_Admins();
            ButtonControl(true, true, false, false, true, false);
        }
    }
}
