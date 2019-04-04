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
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
        }
        clsAdmin admin;
        clsAgent agent;
        bool Addmode;
        int permission;
        int refagent;

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

        public int Refagent
        {
            get
            {
                return refagent;
            }

            set
            {
                refagent = value;
            }
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            agent = new clsAgent();
            admin = new clsAdmin();

            if (permission == 2)
            {
                List<clsClient> temp = new List<clsClient>();
                temp.Add(agent.Searched_Cleint_For_This_Agent(refagent));
                gridAll.DataSource = temp;
            }
            else
            {
                gridAll.DataSource = admin.All_Client();
            }
            gridAll.ReadOnly = true;
            ButtonControl(true, false, false, false, true, false);
            string[] status = { "Seller", "Buyer", "Inactive(Buyer)", "Inactive(Seller)" };
            List<string> refhouses = new List<string>();
            refhouses.Add("0");
            foreach (clsHouse i in admin.Search_All_Houses())
            {
                refhouses.Add(i.RefHouse.ToString());
            }
            cboRefHouse.DataSource = refhouses;
            cboStatus.DataSource = status;
        }
        private void ButtonControl(bool add, bool edit, bool save, bool cancel, bool delete, bool txtboxes)
        {
            btnAdd.Visible = add;
            btnEdit.Visible = edit;
            btnSave.Visible = save;
            btnCancel.Visible = cancel;
            btnDelete.Visible = delete;
            txtName.Enabled = txtPhone.Enabled = txtEmail.Enabled = cboStatus.Enabled = cboRefHouse.Enabled = txtboxes;
        }

        private void gridAll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!txtEmail.Enabled)
            {
                ButtonControl(true, true, false, false, true, false);
                int clientid = (int)gridAll.Rows[e.RowIndex].Cells[0].Value;
                clsClient client = new clsClient();
                client = admin.Searched_Client_by_RefClient(clientid);
                txtName.Text = client.Name;
                txtPhone.Text = client.PhoneNumber;
                txtEmail.Text = client.EMail;
                cboRefHouse.Text = client.RefHouse.ToString();
                cboStatus.Text = client.Status;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (permission == 2)
            {
                MessageBox.Show("To add a client, please confirm with an admin", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txtEmail.Clear();
                txtName.Clear();
                txtPhone.Clear();
                cboRefHouse.SelectedIndex = 0;
                cboStatus.SelectedIndex = 0;

                txtName.Focus();
                ButtonControl(false, false, true, true, false, true);
                Addmode = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtName.Focus();
            ButtonControl(false, false, true, true, false, true);
            Addmode = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsClient client = new clsClient();
            client.Name = txtName.Text;
            client.PhoneNumber = txtPhone.Text;
            client.EMail = txtEmail.Text;
            client.Status = cboStatus.Text;
            client.RefHouse = Convert.ToInt32(cboRefHouse.Text);

            if (Addmode)
            {
                if (admin.Add_New_Client(client))
                {
                    MessageBox.Show("New Client : " + client.Name + " is successfully added", "New Client Added");
                }
                else
                {
                    MessageBox.Show("The Client " + client.Name + " is not added.", "Try Again");
                }
                admin.Refresh_Database();
            }
            else
            {
                client.RefClient = (int)gridAll.Rows[gridAll.CurrentRow.Index].Cells[0].Value;

                if (admin.Edit_Client(client))
                {
                    MessageBox.Show("Client ID " + client.RefHouse + " is successfully modified", "Client Modified");
                }
                else
                {
                    MessageBox.Show("Client ID : " + client.RefHouse + " is not modified.", "Try Again");
                }
            }
            if (permission == 2)
            {
                List<clsClient> temp = new List<clsClient>();
                temp.Add(agent.Searched_Cleint_For_This_Agent(refagent));
                gridAll.DataSource = temp;
            }
            else
                gridAll.DataSource = admin.All_Client();

            ButtonControl(true, true, false, false, true, false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You really want to delete this Client?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int refclient = (int)gridAll.Rows[gridAll.CurrentRow.Index].Cells[0].Value;

                if (admin.Delete_Client(refclient))
                {
                    MessageBox.Show("House ID" + refclient + " is successfully Deleted", "House Deleted");
                }
                else
                {
                    MessageBox.Show("House ID " + refclient + " is not deleted.", "Try Again");
                }
            }
            admin.Refresh_Database();
            if(permission != 2)
            gridAll.DataSource = admin.All_Client();
            else
            {
                List<clsClient> temp = new List<clsClient>();
                temp.Add(agent.Searched_Cleint_For_This_Agent(refagent));
                gridAll.DataSource = temp;
            }
            ButtonControl(true, true, false, false, true, false);
        }
    }
}
