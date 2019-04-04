using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using prgRemaxFinalProject.DataSource;

namespace prgRemaxFinalProject.GUI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtPassword.Enabled = false;
            btnLogin.Enabled = false;
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                txtPassword.Enabled = true;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != "")
            {
                btnLogin.Enabled = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataAccess.ReMax_Database();
            string permission = DataAccess.Login(txtID.Text, txtPassword.Text);
            if (permission == "")
            {
                MessageBox.Show("Login Information is not correct", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int pass_permission = 0;
                string userid = txtID.Text;
                frmMain fm = new frmMain();
                if (permission == "General")
                {
                    pass_permission = 3;
                }
                if (permission == "Agent")
                {
                    pass_permission = 2;
                }
                if (permission == "Admin")
                {
                    pass_permission = 1;
                }
                fm.UserID = userid;
                fm.Permission = pass_permission;
                fm.FormClosed += Fm_FormClosed;
                fm.Show();
                this.Hide();
            }
        }

        private void Fm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
