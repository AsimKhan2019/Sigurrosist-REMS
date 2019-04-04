using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prgRemaxFinalProject.DataSource;
using System.Data;

namespace prgRemaxFinalProject.Business
{
    public class clsAdmin : clsPerson
    {
        int refAdmin;
        string userID;
        string phoneNumber;

        public int RefAdmin
        {
            get
            {
                return refAdmin;
            }

            set
            {
                refAdmin = value;
            }
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

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }

            set
            {
                phoneNumber = value;
            }
        }

        public clsAdmin() : base()
        {
            this.refAdmin = 0;
            this.userID = "";
            base.Name = "";
            this.phoneNumber = "";
        }

        public clsAdmin(int refadmin, string userid, string adminname, string phonenumber) : base(adminname)
        {
            this.refAdmin = refadmin;
            this.userID = userid;
            base.Name = adminname;
            this.phoneNumber = phonenumber;
        }



        public clsAdmin Current_User(string userid)
        {
            return DataAccess.CurrentAdminUser(userid);
        }

        // House searching part
        public List<clsHouse> Search_All_Houses() // Returns all the houses available
        {
            return DataAccess.SearchAllHouse();
        }
        public List<clsHouse> Searched_by_Number_of_Rooms(List<clsHouse> searched_list, int number_of_rooms) // Returns a house list that is refined by the number of rooms (if user says 2, then this list returns the houses that have 2 or more rooms) 
        {
            return DataAccess.SearchHouse_NumberOfRooms(searched_list, number_of_rooms);
        }
        public clsHouse Searched_by_RefHouse(int refhouse) // Returns a house that has the Reference number. Returns Null when no house has the reference number.
        {
            return DataAccess.SearchHouse_RefNumber(refhouse);
        }
        public List<clsHouse> Searched_by_maximum_price(List<clsHouse> searched, decimal price) // Returns houses which have less than the suggested price
        {
            return DataAccess.SearchHouse_less_than_Price(searched, price);
        }

        // Admin management part
        public List<clsAdmin> Search_All_Admins()
        {
            return DataAccess.All_Administrator();
        }
        public bool Add_New_Admin(clsAdmin admin)
        {
            return DataAccess.Add_Admin(admin);
        }

        public bool Edit_Admin(clsAdmin admin)
        {
            return DataAccess.Edit_Admin(admin);
        }
        public bool Delete_Admin(int refadmin)
        {
            return DataAccess.Delete_Admin(refadmin);
        }
        public clsAdmin Searched_admin_by_RefAdmin(int refadmin)
        {
            return DataAccess.SearchAdmin_by_RefAdmin(refadmin);
        }
        // Agent management part
        public List<clsAgent> Search_All_Agents()
        {
            return DataAccess.All_Agent();
        }
        public bool Add_New_Agent(clsAgent agent)
        {
            return DataAccess.Add_Agent(agent);
        }
        public bool Edit_Agent(clsAgent agent)
        {
            return DataAccess.Edit_Agent(agent);
        }
        public void Refresh_Database()
        {
            DataAccess.ReMax_Database();
        }
        public bool Delete_Agent(int refagent)
        {
            return DataAccess.Delete_Agent(refagent);
        }
        // House management Part
        public bool Add_New_House(clsHouse house)
        {
            return DataAccess.Add_House(house);
        }
        public bool Edit_House(clsHouse house)
        {
            return DataAccess.Edit_House(house);
        }
        public bool Delete_House(int refhouse)
        {
            return DataAccess.Delete_House(refhouse);
        }
        // Client management Part
        public List<clsClient> All_Client()
        {
            return DataAccess.All_Client();
        } 
        public bool Add_New_Client(clsClient client)
        {
            return DataAccess.Add_Client(client);
        }
        public bool Edit_Client(clsClient client)
        {
            return DataAccess.Edit_Client(client);
        }
        public bool Delete_Client(int refclient)
        {
            return DataAccess.Delete_Client(refclient);
        }
        public clsClient Searched_Client_by_RefClient(int refclient)
        {
            return DataAccess.SearchClient_by_RefClient(refclient);
        }
        public bool Change_Password(string userid, string old_password, string new_password)
        {
            return DataAccess.Change_Password(userid, old_password, new_password);
        }
        public clsAgent Searched_Agent_with_RefClient(int refclient)
        {
            return DataAccess.Search_Agent_with_RefClient(refclient);
        }
        public List<clsAgent> Searched_Agents_with_Name(string name)
        {
            return DataAccess.Search_Agents_with_Name(name);
        }
        // Sales Management part
        public List<clsSales> All_Sales()
        {
            return DataAccess.All_Sales();
        }
        public DataTable HouseListToDataTable(List<clsHouse> houselist)
        {
            return DataAccess.ListHouse2Table(houselist);
        }
        public DataTable ClientListToDataTable(List<clsClient> clientlist)
        {
            return DataAccess.ListClient2Table(clientlist);
        }
        public DataTable AgentListToDataTable(List<clsAgent> agentlist)
        {
            return DataAccess.ListAgent2Table(agentlist);
        }
        public List<clsSales> Search_Sales_Belong_To_RefAgent(int refagent)
        {
            return DataAccess.Search_Sales_Belong_To_RefAgent(refagent);
        }
        public clsSales Search_Sales_by_RefSales(int refsales)
        {
            return DataAccess.Search_Sales_by_RefSales(refsales);
        }
        public bool Add_Sales(clsSales sales)
        {
            return DataAccess.Add_Sales(sales);
        }
        public bool Edit_Sales(clsSales sales)
        {
            return DataAccess.Edit_Sales(sales);
        }
        public bool Delete_Sales(int refsales)
        {
            return DataAccess.Delete_Sales(refsales);
        }
    }
}
