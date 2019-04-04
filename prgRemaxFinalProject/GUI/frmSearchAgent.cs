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
    public partial class frmSearchAgent : Form
    {
        public frmSearchAgent()
        {
            InitializeComponent();
        }
        clsAdmin admin;
        List<clsAgent> agent_list;
        private void frmSearchAgent_Load(object sender, EventArgs e)
        {
            admin = new clsAdmin();
            admin.Refresh_Database();
            agent_list = new List<clsAgent>();
            agent_list = admin.Search_All_Agents();
            gridAll.DataSource = agent_list;
            // fill cboRefClient
            cboRefClient.DisplayMember = "RefClient";
            cboRefClient.DataSource = admin.All_Client();
        }

        private void btnRefAgent_Click(object sender, EventArgs e)
        {
            clsAgent agent = new clsAgent();
            int refagent = Convert.ToInt32(txtRefAgent.Text);
            agent = agent.Searched_Agent_by_RefAgent(refagent);
            agent_list = new List<clsAgent>();
            agent_list.Add(agent);
            if (agent.RefAgent != 0)
                gridAll.DataSource = agent_list;
            else
                MessageBox.Show("There is no result for given condition.", "NO RESULT");
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            int refclient = Convert.ToInt32(cboRefClient.Text);
            clsAgent agent = new clsAgent();
            agent = admin.Searched_Agent_with_RefClient(refclient);
            agent_list = new List<clsAgent>();
            agent_list.Add(agent);
            if (agent.RefAgent != 0)
                gridAll.DataSource = agent_list;
            else
                MessageBox.Show("There is no result for given condition.", "NO RESULT");
        }

        private void btnName_Click(object sender, EventArgs e)
        {
            agent_list = admin.Searched_Agents_with_Name(txtName.Text);
            if (agent_list.Count() != 0)
                gridAll.DataSource = agent_list;
            else
                MessageBox.Show("There is no result for given condition.", "NO RESULT");
        }
    }
}
