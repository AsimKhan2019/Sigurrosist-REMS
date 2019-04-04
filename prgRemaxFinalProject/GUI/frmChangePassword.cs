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
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }
        string userid;

        public string Userid
        {
            get
            {
                return userid;
            }

            set
            {
                userid = value;
            }
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            txtNewPW.Enabled = false; 
            txtOldPW.Enabled = true;
            txtID.Enabled = false;
            txtID.Text = userid;
            txtID.Focus();
        }

        private void txtOldPW_TextChanged(object sender, EventArgs e)
        {
            if(txtOldPW.Text != "")
            {
                txtNewPW.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtNewPW.Clear();
            txtOldPW.Clear();
            txtID.Focus();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            clsAdmin admin = new clsAdmin();
            if(admin.Change_Password(txtID.Text, txtOldPW.Text, txtNewPW.Text))
            {
                MessageBox.Show("Password for UserID : " + userid + " is changed.", "Successful!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Password for UserID : " + userid + " is not changed.", "Check your password again!");
            }
        }
    }
}
