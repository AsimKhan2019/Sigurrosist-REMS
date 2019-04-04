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
using prgRemaxFinalProject.DataSource;

namespace prgRemaxFinalProject.GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        int permission;
        string userID;
        clsAdmin admin;
        clsAgent agent;
        clsGeneralUser user;
        frmAdminHouse fah;
        frmClient fc;
        frmChangePassword fcp;
        frmSales fs;
        public int Permission
        {
            get { return permission; }
            set { permission = value; }
        }

        public string UserID
        {
            get
            {
                return userID;
            }

            set
            {
                userID = value;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (permission == 1)
            {
                MenuControl(true, true, true, true, true);
                admin = new clsAdmin();
                admin = admin.Current_User(userID);
                MessageBox.Show("Hello, " + admin.Name);
            }
            if (permission == 2)
            {
                MenuControl(false, false, true, true, true);
                agent = new clsAgent();
                agent = agent.Current_User(userID);
                MessageBox.Show("Hello, " + agent.Name);
            }
            if (permission == 3)
            {
                MenuControl(false, false, false, false, false);
                user = new clsGeneralUser();
                user = user.Current_User(userID);
                MessageBox.Show("Hello, " + user.Name);
            }
        }

        private void MenuControl(bool admin, bool agent, bool house, bool client, bool sales)
        {
            mnuAdmin.Visible = admin;
            mnuAgent.Visible = agent;
            mnuHouse.Visible = house;
            mnuClient.Visible = client;
            mnuSales.Visible = sales;
        }

        private void mnuAdmin_Click(object sender, EventArgs e)
        {
            frmAdminAdmin fad = new frmAdminAdmin();
            fad.MdiParent = this;
            fad.Show();
        }

        private void mnuAgent_Click(object sender, EventArgs e)
        {
            frmAdminAgent fag = new frmAdminAgent();
            fag.MdiParent = this;
            fag.Show();
        }

        private void mnuHouse_Click(object sender, EventArgs e)
        {
            fah = new frmAdminHouse();
            if (permission == 1)
            {
                fah.Permission = permission;
                fah.RefAgent = 0;
            }
            if (permission == 2)
            {
                fah.Permission = permission;
                fah.RefAgent = agent.RefAgent;
            }
            if (permission == 3)
            {
                fah.Permission = permission;
                fah.RefAgent = 0;
            }
            fah.MdiParent = this;
            fah.Show();
        }

        private void mnuClient_Click(object sender, EventArgs e)
        {
            fc = new frmClient();
            if (permission == 1)
            {
                fc.Permission = permission;
                fc.Refagent = 0;
            }
            if (permission == 2)
            {
                fc.Permission = permission;
                fc.Refagent = agent.RefAgent;
            }
            if (permission == 3)
            {
                fc.Permission = permission;
                fc.Refagent = 0;
            }
            fc.MdiParent = this;
            fc.Show();
        }

        private void mnuPassword_Click(object sender, EventArgs e)
        {
            fcp = new frmChangePassword();
            fcp.Userid = UserID;
            fcp.MdiParent = this;
            fcp.Show();
        }

        private void houseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearchHouse fsh = new frmSearchHouse();
            fsh.MdiParent = this;
            fsh.Show();
        }

        private void mnuSearchAgents_Click(object sender, EventArgs e)
        {
            frmSearchAgent fsa = new frmSearchAgent();
            fsa.MdiParent = this;
            fsa.Show();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit the program?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void mnuSales_Click(object sender, EventArgs e)
        {
            fs = new frmSales();
            if (permission == 1)
            {
                fs.Permission = permission;
                fs.RefAgent = 0;
            }
            if (permission == 2)
            {
                fs.Permission = permission;
                fs.RefAgent = agent.RefAgent;
            }
            if (permission == 3)
            {
                fs.Permission = permission;
                fs.RefAgent = 0;
            }
            fs.MdiParent = this;
            fs.Show();
        }
    }
}
