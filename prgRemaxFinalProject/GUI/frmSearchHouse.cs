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
    public partial class frmSearchHouse : Form
    {
        public frmSearchHouse()
        {
            InitializeComponent();
        }
        clsAdmin admin = new clsAdmin();
        List<clsHouse> houselist;
        private void frmSearchHouse_Load(object sender, EventArgs e)
        {
            houselist = new List<clsHouse>();
            admin.Refresh_Database();
            houselist = admin.Search_All_Houses();
            gridAll.DataSource = houselist;
            string[] rooms = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11" };
            cboNumRoom.DataSource = rooms;
            cboNumRoomCombile.DataSource = rooms;
        }

        private void btnRefHouse_Click(object sender, EventArgs e)
        {
            clsHouse house = admin.Searched_by_RefHouse(Convert.ToInt32(txtRefHouse.Text));
            houselist = new List<clsHouse>();
            houselist.Add(house);
            if (houselist.Count() != 0)
                gridAll.DataSource = houselist;
            else
                MessageBox.Show("There is no result with the RefHouse", "NO RESULT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnNumRoom_Click(object sender, EventArgs e)
        {
            int numofrooms = Convert.ToInt32(cboNumRoom.SelectedItem);
            houselist = admin.Searched_by_Number_of_Rooms(admin.Search_All_Houses(), numofrooms);
            if (houselist.Count() != 0)
                gridAll.DataSource = houselist;
            else
                MessageBox.Show("There is no result with the condition", "NO RESULT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnBudget_Click(object sender, EventArgs e)
        {
            decimal budget = Convert.ToDecimal(txtBudget.Text);
            houselist = admin.Searched_by_maximum_price(admin.Search_All_Houses(), budget);
            if (houselist.Count() != 0)
                gridAll.DataSource = houselist;
            else
                MessageBox.Show("There is no result with the condition", "NO RESULT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnCombine_Click(object sender, EventArgs e)
        {
            int numofrooms = Convert.ToInt32(cboNumRoomCombile.SelectedItem);
            decimal budget = Convert.ToDecimal(txtBudgetCombine.Text);

            houselist = admin.Searched_by_Number_of_Rooms(admin.Search_All_Houses(), numofrooms);
            houselist = admin.Searched_by_maximum_price(houselist, budget);
            if (houselist.Count() != 0)
                gridAll.DataSource = houselist;
            else
                MessageBox.Show("There is no result with the condition", "NO RESULT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
