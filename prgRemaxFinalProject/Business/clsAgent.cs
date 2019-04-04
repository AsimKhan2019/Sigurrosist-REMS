using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using prgRemaxFinalProject.DataSource;

namespace prgRemaxFinalProject.Business
{
    public class clsAgent : clsPerson
    {
        int refAgent;
        string userID;
        string phoneNumber;
        int salesPoint;
        int refClient;

        public int RefAgent
        {
            get
            {
                return refAgent;
            }

            set
            {
                refAgent = value;
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

        public int SalesPoint
        {
            get
            {
                return salesPoint;
            }

            set
            {
                salesPoint = value;
            }
        }

        public int RefClient
        {
            get
            {
                return refClient;
            }

            set
            {
                refClient = value;
            }
        }

        public clsAgent() : base()
        {
            this.refAgent = 0;
            base.Name = "";
            this.userID = "";
            this.phoneNumber = "";
            this.salesPoint = 0;
            this.refClient = 0;
        }

        public clsAgent(int refagent, string agentname, string userid, string phonenumber, int salespoint, int refclient) : base(agentname)
        {
            this.refAgent = refagent;
            base.Name = agentname;
            this.userID = userid;
            this.phoneNumber = phonenumber;
            this.salesPoint = salespoint;
            this.refClient = refclient;
        }


        public clsAgent Current_User (string userid)
        {
            return DataAccess.CurrentAgentUser(userid);
        }
        public clsAgent Searched_Agent_by_RefAgent(int refagent)
        {
            return DataAccess.SearchAgent_by_RefAgent(refagent);
        }

        // Searching House Functions
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
        public DataTable Searched_House_Belong_to_Current_Agent(int refagent)
        {
            return DataAccess.SearchHouse_Agent_For_Management(refagent);
        }
        public clsHouse Searched_House_for_This_Agent(int refagent)
        {
            return DataAccess.SearchHouse_Agent_Management(refagent);
        }

        // Searching Client Functions
        public clsClient Searched_Cleint_For_This_Agent(int refagent)
        {
            return DataAccess.Search_Client_Belong_to_Agent(refagent);
        }

    }
}
