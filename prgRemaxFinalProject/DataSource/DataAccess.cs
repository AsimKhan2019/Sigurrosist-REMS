using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prgRemaxFinalProject.Business;
using System.Data.OleDb;
using System.Data;

namespace prgRemaxFinalProject.DataSource
{
    static public class DataAccess
    {
        static OleDbConnection myCon;
        static OleDbDataAdapter adpAdmin, adpAgent, adpClient, adpGuser, adpHouse, adpUser, adpSales;
        static DataSet mySet;

        static public void ReMax_Database()
        {
            myCon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Data\\Remax.mdb");
            myCon.Open();
            OleDbCommand getAdmin = new OleDbCommand("select * from Admins", myCon);
            adpAdmin = new OleDbDataAdapter(getAdmin);
            OleDbCommand getAgent = new OleDbCommand("select * from Agents", myCon);
            adpAgent = new OleDbDataAdapter(getAgent);
            OleDbCommand getClient = new OleDbCommand("select * from Clients", myCon);
            adpClient = new OleDbDataAdapter(getClient);
            OleDbCommand getGeneralUser = new OleDbCommand("select * from GeneralUsers", myCon);
            adpGuser = new OleDbDataAdapter(getGeneralUser);
            OleDbCommand getHouse = new OleDbCommand("select * from Houses", myCon);
            adpHouse = new OleDbDataAdapter(getHouse);
            OleDbCommand getSales = new OleDbCommand("select * from Sales", myCon);
            adpSales = new OleDbDataAdapter(getSales);
            OleDbCommand getUser = new OleDbCommand("select * from Users", myCon);
            adpUser = new OleDbDataAdapter(getUser);

            mySet = new DataSet();
            adpAdmin.Fill(mySet, "Admins");
            adpAgent.Fill(mySet, "Agents");
            adpClient.Fill(mySet, "Clients");
            adpGuser.Fill(mySet, "GeneralUsers");
            adpHouse.Fill(mySet, "Houses");
            adpSales.Fill(mySet, "Sales");
            adpUser.Fill(mySet, "Users");
        }
    
        static public clsAdmin CurrentAdminUser(string userid)// returning current user(admin)
        {
            clsAdmin temp = new clsAdmin();
            DataRow[] cadmin = mySet.Tables["Admins"].Select("UserID = '" + userid + "'");
            if (cadmin.Count() != 0)
            {
                temp.RefAdmin = (int)(cadmin[0]["RefAdmin"]);
                temp.Name = cadmin[0]["AdminName"].ToString();
                temp.UserID = cadmin[0]["UserID"].ToString();
                temp.PhoneNumber = cadmin[0]["PhoneNumber"].ToString();
            }
            return temp;
        }


        static public clsAgent CurrentAgentUser(string userid)// returning current user(agent)
        {
            clsAgent temp = new clsAgent();
            DataRow[] cagent = mySet.Tables["Agents"].Select("UserID = '" + userid + "'");
            if (cagent.Count() != 0)
            {
                temp.RefAgent = (int)(cagent[0]["RefAgent"]);
                temp.Name = cagent[0]["AgentName"].ToString();
                temp.UserID = cagent[0]["UserID"].ToString();
                temp.PhoneNumber = cagent[0]["PhoneNumber"].ToString();
                temp.SalesPoint = (int)(cagent[0]["SalesPoint"]);
                temp.RefClient = (int)(cagent[0]["RefClient"]);
            }
            return temp;
        }

        static public clsGeneralUser CurrentGeneralUser(string userid)// returning current user(general user)
        {
            clsGeneralUser temp = new clsGeneralUser();
            DataRow[] guser = mySet.Tables["GeneralUsers"].Select("UserID = '" + userid + "'");
            if (guser.Count() != 0)
            {
                temp.RefGeneralUser = (int)(guser[0]["RefGeneralUser"]);
                temp.Name = guser[0]["UserName"].ToString();
                temp.UserID = guser[0]["UserID"].ToString();
                temp.UserDescription = guser[0]["UserDescription"].ToString();
            }
            return temp;
        }

        static public List<clsHouse> SearchAllHouse()
        {
            List<clsHouse> templist = new List<clsHouse>();
            clsHouse temp;
            foreach(DataRow i in mySet.Tables["Houses"].Rows)
            {
                temp = new clsHouse();
                temp.RefHouse = (int)i["RefHouse"];
                temp.Address = i["Address"].ToString();
                temp.Area = (int)i["Area"];
                temp.Price = (decimal)i["Price"];
                temp.Floor = (int)i["Floor"];
                temp.NumRoom = (int)i["NumberOfRooms"];
                temp.NumBath = (int)i["NumberOfBathrooms"];
                temp.Accessible = (bool)i["WheelchairAccessible"];
                temp.Status = i["Status"].ToString();
                templist.Add(temp);
            }
            return templist;
        }

        static public List<clsHouse> SearchHouse_NumberOfRooms(List<clsHouse> searched, int number_of_rooms)
        {
            List<clsHouse> templist = new List<clsHouse>();
            foreach (clsHouse i in searched)
            {
                if (i.NumRoom >= number_of_rooms)
                {
                    templist.Add(i);
                }
            }
            return templist;
        }

        static public clsHouse SearchHouse_RefNumber(int refhouse) 
        {
            clsHouse temp = new clsHouse();
            foreach (clsHouse i in SearchAllHouse())
            {
                if (i.RefHouse == refhouse)
                {
                    temp = i;
                    break;
                }
            }
            return temp;
        }
        static public List<clsHouse> SearchHouse_less_than_Price(List<clsHouse> searched, decimal price)
        {
            List<clsHouse> templist = new List<clsHouse>();
            foreach (clsHouse i in searched)
            {
                if (i.Price <= price)
                {
                    templist.Add(i);
                }
            }
            return templist;
        }

        static public string Login(string id, string password) // returns the permission of the user, or null value "" when the login information is not correct
        {
            string temp = "";
            foreach (DataRow i in mySet.Tables["Users"].Rows)
            {
                if ((i["UserID"].ToString() == id) && (i["UserPassword"].ToString() == password))
                {
                    temp = i["Permission"].ToString();
                    break;
                }
            }
            return temp;
        }

        static public List<clsAdmin> All_Administrator()
        {
            List<clsAdmin> templist = new List<clsAdmin>();
            clsAdmin temp;
            foreach (DataRow i in mySet.Tables["Admins"].Rows)
            {
                temp = new clsAdmin();
                temp.RefAdmin = (int)i["RefAdmin"];
                temp.UserID = i["UserID"].ToString();
                temp.Name = i["AdminName"].ToString();
                temp.PhoneNumber = i["PhoneNumber"].ToString();
                templist.Add(temp);
            }
            return templist;
        }
        static public List<clsAgent> All_Agent()
        {
            List<clsAgent> templist = new List<clsAgent>();
            clsAgent temp;
            foreach (DataRow i in mySet.Tables["Agents"].Rows)
            {
                temp = new clsAgent();
                temp.RefAgent = Convert.ToInt32(i["RefAgent"]);
                temp.UserID = i["UserID"].ToString();
                temp.Name = i["AgentName"].ToString();
                temp.PhoneNumber = i["PhoneNumber"].ToString();
                temp.SalesPoint = (int)i["SalesPoint"];
                temp.RefClient = (int)i["RefClient"];
                templist.Add(temp);
            }
            return templist;
        }
        static public bool Add_Admin(clsAdmin admin)
        {
            bool job_done = false;
            try
            {
                DataRow myRow = mySet.Tables["Admins"].NewRow();
                myRow["UserID"] = admin.UserID;
                myRow["AdminName"] = admin.Name;
                myRow["PhoneNumber"] = admin.PhoneNumber;
                mySet.Tables["Admins"].Rows.Add(myRow);
                OleDbCommandBuilder myBuild = new OleDbCommandBuilder(adpAdmin);
                adpAdmin.Update(mySet.Tables["Admins"]);
                job_done = true;
            }
            catch
            {
                job_done = false;
            }
            return job_done;
        }
        static public clsAdmin SearchAdmin_by_RefAdmin(int refadmin)
        {
            clsAdmin temp = new clsAdmin();
            DataRow[] find = mySet.Tables["Admins"].Select("RefAdmin = " + refadmin);
            if (find.Count() != 0)
            {
                temp.RefAdmin = (int)(find[0]["RefAdmin"]);
                temp.Name = find[0]["AdminName"].ToString();
                temp.UserID = find[0]["UserID"].ToString();
                temp.PhoneNumber = find[0]["PhoneNumber"].ToString();
            }
            return temp;
        }
        static public bool Edit_Admin(clsAdmin admin)
        {
            bool job_done = false;

            clsAdmin edit = new clsAdmin();
            edit = edit.Searched_admin_by_RefAdmin(admin.RefAdmin);
            foreach (DataRow i in mySet.Tables["Admins"].Rows)
            {
                if ((int)i["RefAdmin"] == admin.RefAdmin)
                {
                    i["UserID"] = admin.UserID;
                    i["AdminName"] = admin.Name;
                    i["PhoneNumber"] = admin.PhoneNumber;
                    OleDbCommandBuilder myBuild = new OleDbCommandBuilder(adpAdmin);
                    adpAdmin.Update(mySet.Tables["Admins"]);
                    job_done = true;
                    break;
                }
            }
            return job_done;
        }
        static public bool Delete_Admin(int refadmin)
        {
            bool job_done = false;
            int currentrow = 0;
            foreach (DataRow i in mySet.Tables["Admins"].Rows)
            {
                if ((int)i["RefAdmin"] == refadmin)
                {
                    string id = i["UserID"].ToString();
                    mySet.Tables["Admins"].Rows[currentrow].Delete();
                    OleDbCommandBuilder myBuild = new OleDbCommandBuilder(adpAdmin);
                    adpAdmin.Update(mySet.Tables["Admins"]);
                    currentrow = 0;
                    foreach (DataRow index in mySet.Tables["Users"].Rows)
                    {
                        if (index["UserID"].ToString() == id)
                        {
                            mySet.Tables["Users"].Rows[currentrow].Delete();
                            myBuild = new OleDbCommandBuilder(adpUser);
                            adpUser.Update(mySet.Tables["Users"]);
                            break;
                        }
                        currentrow++;
                    }                 
                    job_done = true;
                    break;
                }
                currentrow++;
            }
            return job_done;
        }

        static public bool Add_Agent(clsAgent agent)
        {
            bool job_done = false;
            
            {
                DataRow myRow = mySet.Tables["Agents"].NewRow();
                myRow["UserID"] = agent.UserID;
                myRow["AgentName"] = agent.Name;
                myRow["PhoneNumber"] = agent.PhoneNumber;
                myRow["SalesPoint"] = agent.SalesPoint;
                myRow["RefClient"] = agent.RefClient;
                mySet.Tables["Agents"].Rows.Add(myRow);
                OleDbCommandBuilder myBuild = new OleDbCommandBuilder(adpAgent);
                adpAgent.Update(mySet.Tables["Agents"]);
                job_done = true;
            }

            return job_done;
        }
        static public bool Edit_Agent(clsAgent agent)
        {
            bool job_done = false;

            clsAdmin edit = new clsAdmin();
            foreach (DataRow i in mySet.Tables["Agents"].Rows)
            {
                if ((int)i["RefAgent"] == agent.RefAgent)
                {
                    i["UserID"] = agent.UserID;
                    i["AgentName"] = agent.Name;
                    i["PhoneNumber"] = agent.PhoneNumber;
                    i["SalesPoint"] = agent.SalesPoint;
                    i["RefClient"] = agent.RefClient;
                    OleDbCommandBuilder myBuild = new OleDbCommandBuilder(adpAgent);
                    adpAgent.Update(mySet.Tables["Agents"]);
                    job_done = true;
                    break;
                }
            }
            return job_done;
        }
        static public bool Delete_Agent(int refagent)
        {
            bool job_done = false;
            int currentrow = 0;
            foreach (DataRow i in mySet.Tables["Agents"].Rows)
            {
                if ((int)i["RefAgent"] == refagent)
                {
                    string id = i["UserID"].ToString();
                    mySet.Tables["Agents"].Rows[currentrow].Delete();
                    OleDbCommandBuilder myBuild = new OleDbCommandBuilder(adpAgent);
                    adpAgent.Update(mySet.Tables["Agents"]);
                    currentrow = 0;
                    foreach (DataRow index in mySet.Tables["Users"].Rows)
                    {
                        if (index["UserID"].ToString() == id)
                        {
                            mySet.Tables["Users"].Rows[currentrow].Delete();
                            myBuild = new OleDbCommandBuilder(adpUser);
                            adpUser.Update(mySet.Tables["Users"]);
                            break;
                        }
                        currentrow++;
                    }
                    job_done = true;
                    break;
                }
                currentrow++;
            }
            return job_done;
        }
        static public clsAgent SearchAgent_by_RefAgent(int refagent)
        {
            clsAgent temp = new clsAgent();
            DataRow[] find = mySet.Tables["Agents"].Select("RefAgent = " + refagent);
            if (find.Count() != 0)
            {
                temp.RefAgent = refagent;
                temp.Name = find[0]["AgentName"].ToString();
                temp.UserID = find[0]["UserID"].ToString();
                temp.PhoneNumber = find[0]["PhoneNumber"].ToString();
                temp.SalesPoint = (int)find[0]["SalesPoint"];
                temp.RefClient = (int)find[0]["RefClient"];
            }
            return temp;
        }
        static public clsClient SearchClient_by_RefClient(int refclient)
        {
            clsClient temp = new clsClient();
            foreach(DataRow i in mySet.Tables["Clients"].Rows)
            {
                if((int)i["RefClient"] == refclient)
                {
                    temp.RefClient = refclient;
                    temp.Name = i["ClientName"].ToString();
                    temp.PhoneNumber = i["PhoneNumber"].ToString();
                    temp.EMail = i["Email"].ToString();
                    temp.Status = i["Status"].ToString();
                    if (temp.Status.ToString() != "Buyer")
                        temp.RefHouse = (int)i["RefHouse"];
                }
            }
            return temp;
        }
        static public clsHouse SearchHouse_Agent_Management(int refagent)
        {
            clsAgent tmp = new clsAgent();
            clsClient cl = new clsClient();
            int refclient_agent = tmp.Searched_Agent_by_RefAgent(refagent).RefClient;
            int refhouse_client = cl.Searched_Client_by_RefClient(refclient_agent).RefHouse;
            clsHouse tmphouse = tmp.Searched_by_RefHouse(refhouse_client);
            return tmphouse;
        }

        static public DataTable SearchHouse_Agent_For_Management(int refagent)
        {
            DataTable temp = mySet.Tables["Houses"].Clone();
            DataRow tmp = temp.NewRow();
            tmp["RefHouse"] = SearchHouse_Agent_Management(refagent).RefHouse.ToString();
            tmp["Address"] = SearchHouse_Agent_Management(refagent).Address;
            tmp["Area"] = SearchHouse_Agent_Management(refagent).Area.ToString();
            tmp["Price"] = SearchHouse_Agent_Management(refagent).Price.ToString();
            tmp["Floor"] = SearchHouse_Agent_Management(refagent).Floor.ToString();
            tmp["NumberOfRooms"] = SearchHouse_Agent_Management(refagent).NumRoom.ToString();
            tmp["NumberOfBathrooms"] = SearchHouse_Agent_Management(refagent).NumBath.ToString();
            tmp["WheelchairAccessible"] = SearchHouse_Agent_Management(refagent).Accessible.ToString();
            tmp["Status"] = SearchHouse_Agent_Management(refagent).Status;

            temp.Rows.Add(tmp);
            return temp;
        }

        static public bool Add_House (clsHouse house)
        {
            bool job_done = false;
            try
            {
                DataRow myRow = mySet.Tables["Houses"].NewRow();
                myRow["RefHouse"] = house.RefHouse.ToString();
                myRow["Address"] = house.Address;
                myRow["Area"] = house.Area.ToString();
                myRow["Price"] = house.Price.ToString();
                myRow["Floor"] = house.Floor.ToString();
                myRow["NumberOfRooms"] = house.NumRoom.ToString();
                myRow["NumberOfBathrooms"] = house.NumBath.ToString();
                myRow["WheelchairAccessible"] = house.Accessible.ToString();
                myRow["Status"] = house.Status;
                mySet.Tables["Houses"].Rows.Add(myRow);
                OleDbCommandBuilder myBuild = new OleDbCommandBuilder(adpHouse);
                adpHouse.Update(mySet.Tables["Houses"]);
                job_done = true;
            }
            catch
            {
                job_done = false;
            }
            return job_done;
        }
        static public bool Edit_House(clsHouse house)
        {
            bool job_done = false;

            foreach (DataRow myRow in mySet.Tables["Houses"].Rows)
            {
                if ((int)myRow["RefHouse"] == house.RefHouse)
                {
                    myRow["RefHouse"] = house.RefHouse.ToString();
                    myRow["Address"] = house.Address;
                    myRow["Area"] = house.Area.ToString();
                    myRow["Price"] = house.Price.ToString();
                    myRow["Floor"] = house.Floor.ToString();
                    myRow["NumberOfRooms"] = house.NumRoom.ToString();
                    myRow["NumberOfBathrooms"] = house.NumBath.ToString();
                    myRow["WheelchairAccessible"] = house.Accessible.ToString();
                    myRow["Status"] = house.Status;
                    OleDbCommandBuilder myBuild = new OleDbCommandBuilder(adpHouse);
                    adpHouse.Update(mySet.Tables["Houses"]);
                    job_done = true;
                    break;
                }
            }
            return job_done;
        }

        static public bool Delete_House(int refhouse)
        {
            bool job_done = false;
            int currentrow = 0;
            foreach (DataRow i in mySet.Tables["Houses"].Rows)
            {
                if ((int)i["RefHouse"] == refhouse)
                {
                    mySet.Tables["Houses"].Rows[currentrow].Delete();
                    OleDbCommandBuilder myBuild = new OleDbCommandBuilder(adpHouse);
                    adpHouse.Update(mySet.Tables["Houses"]);

                    job_done = true;
                    break;
                }
                currentrow++;
            }
            return job_done;
        }
        static public List<clsClient> All_Client()
        {
            List<clsClient> temp_list = new List<clsClient>();
            clsClient temp;
            foreach(DataRow i in mySet.Tables["Clients"].Rows)
            {
                temp = new clsClient();
                temp.RefClient = (int)i["RefClient"];
                temp.Name = i["ClientName"].ToString();
                temp.PhoneNumber = i["PhoneNumber"].ToString();
                temp.EMail = i["Email"].ToString();
                temp.Status = i["Status"].ToString();
                if(temp.Status.ToString() != "Buyer")
                temp.RefHouse = (int)i["RefHouse"];
                temp_list.Add(temp);
            }
            return temp_list;
        }

        static public clsClient Search_Client_Belong_to_Agent(int refagent)
        {
            clsAgent tmp = new clsAgent();
            clsClient cl = new clsClient();
            int refclient_agent = tmp.Searched_Agent_by_RefAgent(refagent).RefClient;
            cl = cl.Searched_Client_by_RefClient(refclient_agent);
            return cl;
        }

        static public bool Add_Client(clsClient client)
        {
            bool job_done = false;
            try
            {
                DataRow myRow = mySet.Tables["Clients"].NewRow();
                myRow["RefClient"] = client.RefClient.ToString();
                myRow["ClientName"] = client.Name;
                myRow["PhoneNumber"] = client.PhoneNumber;
                myRow["Email"] = client.EMail;
                myRow["Status"] = client.Status;
                if (myRow["Status"].ToString() != "Buyer")
                    myRow["RefHouse"] = client.RefHouse.ToString();
                mySet.Tables["Clients"].Rows.Add(myRow);
                OleDbCommandBuilder myBuild = new OleDbCommandBuilder(adpClient);
                adpClient.Update(mySet.Tables["Clients"]);
                job_done = true;
            }
            catch
            {
                job_done = false;
            }
            return job_done;
        }
        static public bool Edit_Client(clsClient client)
        {
            bool job_done = false;

            foreach (DataRow myRow in mySet.Tables["Clients"].Rows)
            {
                if ((int)myRow["RefClient"] == client.RefClient)
                {
                    myRow["ClientName"] = client.Name;
                    myRow["PhoneNumber"] = client.PhoneNumber;
                    myRow["Email"] = client.EMail;
                    myRow["Status"] = client.Status;
                    if (myRow["Status"].ToString() != "Buyer")
                    myRow["RefHouse"] = client.RefHouse.ToString();
                    OleDbCommandBuilder myBuild = new OleDbCommandBuilder(adpClient);
                    adpClient.Update(mySet.Tables["Clients"]);
                    job_done = true;
                    break;
                }
            }
            return job_done;
        }
        static public bool Delete_Client(int refclient)
        {
            bool job_done = false;
            int currentrow = 0;
            foreach (DataRow i in mySet.Tables["Clients"].Rows)
            {
                if ((int)i["RefClient"] == refclient)
                {
                    mySet.Tables["Clients"].Rows[currentrow].Delete();
                    OleDbCommandBuilder myBuild = new OleDbCommandBuilder(adpClient);
                    adpClient.Update(mySet.Tables["Clients"]);
                    job_done = true;
                    break;
                }
                currentrow++;
            }
            return job_done;
        }

        static public bool Change_Password(string userid, string password, string newpassword)
        {
            bool job_done = false;
            string permission = Login(userid, password);
            if (permission == "")
            {
                job_done = false;
            }
            else
            {
                foreach (DataRow i in mySet.Tables["Users"].Rows)
                {
                    if (i["UserID"].ToString() == userid)
                    {
                        i["UserPassword"] = newpassword;
                        OleDbCommandBuilder myBuild = new OleDbCommandBuilder(adpUser);
                        adpUser.Update(mySet.Tables["Users"]);
                        job_done = true;
                        break;
                    }
                }
            }
            return job_done;
        }

        static public clsAgent Search_Agent_with_RefClient(int refclient)
        {
            clsAgent temp = new clsAgent();

            foreach(DataRow i in mySet.Tables["Agents"].Rows)
            {
                if (i["RefClient"].ToString() == refclient.ToString())
                {
                    temp.RefAgent = (int)i["RefAgent"];
                    temp.Name = i["AgentName"].ToString();
                    temp.UserID = i["UserID"].ToString();
                    temp.PhoneNumber = i["PhoneNumber"].ToString();
                    temp.SalesPoint = (int)i["SalesPoint"];
                    temp.RefClient = (int)i["RefClient"];
                    break;
                }
            }
            return temp;
        }

        static public List<clsAgent> Search_Agents_with_Name(string name)
        {
            List<clsAgent> temp_list = new List<clsAgent>();

            foreach (DataRow i in mySet.Tables["Agents"].Rows)
            {
                if (i["AgentName"].ToString().Contains(name))
                {
                    clsAgent temp = new clsAgent();
                    temp.RefAgent = (int)i["RefAgent"];
                    temp.Name = i["AgentName"].ToString();
                    temp.UserID = i["UserID"].ToString();
                    temp.PhoneNumber = i["PhoneNumber"].ToString();
                    temp.SalesPoint = (int)i["SalesPoint"];
                    temp.RefClient = (int)i["RefClient"];
                    temp_list.Add(temp);
                }
            }
            return temp_list;
        }

        static public List<clsSales> All_Sales()
        {
            List<clsSales> temp_list = new List<clsSales>();
            clsSales sales;
            foreach (DataRow i in mySet.Tables["Sales"].Rows)
            {
                sales = new clsSales();
                sales.RefSales = (int)i["RefSales"];
                sales.RefHouse = (int)i["RefHouse"];
                sales.RefClient = (int)i["RefClient"];
                sales.RefAgent = (int)i["RefAgent"];
                sales.Description = i["Description"].ToString();
                sales.SalesDate = DateTime.Parse(i["SalesDate"].ToString());
                temp_list.Add(sales);
            }
            return temp_list;
        }
        static public DataTable ListHouse2Table(List<clsHouse> houselist)
        {
            DataTable temp = new DataTable();
            temp = mySet.Tables["Houses"].Clone();
            DataRow myRow;
            foreach(clsHouse i in SearchAllHouse())
            {
                myRow = temp.NewRow();
                myRow["RefHouse"] = i.RefHouse.ToString();
                myRow["Address"] = i.Address;
                myRow["Area"] = i.Area.ToString();
                myRow["Price"] = i.Price.ToString();
                myRow["Floor"] = i.Floor.ToString();
                myRow["NumberOfRooms"] = i.NumRoom.ToString();
                myRow["NumberOfBathrooms"] = i.NumBath.ToString();
                myRow["WheelchairAccessible"] = i.Accessible.ToString();
                myRow["Status"] = i.Status;
                temp.Rows.Add(myRow);
            }
            return temp;
        }
        static public DataTable ListClient2Table(List<clsClient> clientlist)
        {
            DataTable temp = new DataTable();
            temp = mySet.Tables["Clients"].Clone();
            DataRow myRow;
            foreach (clsClient i in All_Client())
            {
                myRow = temp.NewRow();
                myRow["RefClient"] = i.RefClient.ToString();
                myRow["ClientName"] = i.Name;
                myRow["PhoneNumber"] = i.PhoneNumber;
                myRow["Email"] = i.EMail;
                myRow["Status"] = i.Status;
                if (myRow["Status"].ToString() != "Buyer")
                    myRow["RefHouse"] = i.RefHouse.ToString();
                temp.Rows.Add(myRow);
            }
            return temp;


        }
        static public DataTable ListAgent2Table(List<clsAgent> agentlist)
        {
            DataTable temp = new DataTable();
            temp = mySet.Tables["Agents"].Clone();
            DataRow myRow;
            foreach (clsAgent i in All_Agent())
            {
                myRow = temp.NewRow();
                myRow["RefAgent"] = i.RefAgent;
                myRow["UserID"] = i.UserID;
                myRow["AgentName"] = i.Name;
                myRow["PhoneNumber"] = i.PhoneNumber;
                myRow["SalesPoint"] = i.SalesPoint;
                myRow["RefClient"] = i.RefClient;
                temp.Rows.Add(myRow);
            }
            return temp;
        }

        static public List<clsSales> Search_Sales_Belong_To_RefAgent(int refagent)
        {
            List<clsSales> temp_list = new List<clsSales>();
            clsSales temp;
            foreach(DataRow i in mySet.Tables["Sales"].Rows)
            {
                if (i["RefAgent"].ToString() == refagent.ToString())
                {
                    temp = new clsSales();
                    temp.RefSales = (int)i["RefSales"];
                    temp.RefAgent = (int)i["RefAgent"];
                    temp.RefClient = (int)i["RefClient"];
                    temp.RefHouse = (int)i["RefHouse"];
                    temp.SalesDate = DateTime.Parse(i["SalesDate"].ToString());
                    temp.Description = i["Description"].ToString();
                    temp_list.Add(temp);
                }
            }
            return temp_list;
        }
        static public clsSales Search_Sales_by_RefSales(int refsales)
        {
            clsSales temp = new clsSales();
            foreach (DataRow i in mySet.Tables["Sales"].Rows)
            {
                if (i["RefSales"].ToString() == refsales.ToString())
                {
                    temp.RefSales = (int)i["RefSales"];
                    temp.RefHouse = (int)i["RefHouse"];
                    temp.RefClient = (int)i["RefClient"];
                    temp.RefAgent = (int)i["RefAgent"];               
                    temp.Description = i["Description"].ToString();
                    temp.SalesDate = DateTime.Parse(i["SalesDate"].ToString());
                    break;
                }
            }
            return temp;
        }
        static public bool Add_Sales(clsSales sales)
        {
            bool job_done = false;
            try
            {
                DataRow myRow = mySet.Tables["Sales"].NewRow();
                myRow["RefSales"] = sales.RefSales;
                myRow["RefHouse"] = sales.RefHouse;
                myRow["RefClient"] = sales.RefClient;
                myRow["RefAgent"] = sales.RefAgent;
                myRow["Description"] = sales.Description;
                myRow["SalesDate"] = sales.SalesDate;
                mySet.Tables["Sales"].Rows.Add(myRow);
                OleDbCommandBuilder myBuild = new OleDbCommandBuilder(adpSales);
                adpSales.Update(mySet.Tables["Sales"]);
                job_done = true;
            }
            catch
            {
                job_done = false;
            }
            return job_done;
        }
        static public bool Edit_Sales(clsSales sales)
        {
            bool job_done = false;

            foreach (DataRow myRow in mySet.Tables["Sales"].Rows)
            {
                if ((int)myRow["RefSales"] == sales.RefSales)
                {
                    myRow["RefHouse"] = sales.RefHouse;
                    myRow["RefClient"] = sales.RefClient;
                    myRow["RefAgent"] = sales.RefAgent;
                    myRow["Description"] = sales.Description;
                    myRow["SalesDate"] = sales.SalesDate;
                    OleDbCommandBuilder myBuild = new OleDbCommandBuilder(adpSales);
                    adpSales.Update(mySet.Tables["Sales"]);
                    job_done = true;
                    break;
                }
            }
            return job_done;
        }
        static public bool Delete_Sales(int refsales)
        {
            bool job_done = false;
            int currentrow = 0;
            foreach (DataRow i in mySet.Tables["Sales"].Rows)
            {
                if ((int)i["RefSales"] == refsales)
                {
                    mySet.Tables["Sales"].Rows[currentrow].Delete();
                    OleDbCommandBuilder myBuild = new OleDbCommandBuilder(adpSales);
                    adpSales.Update(mySet.Tables["Sales"]);
                    job_done = true;
                    break;
                }
                currentrow++;
            }
            return job_done;
        }
    }
}
