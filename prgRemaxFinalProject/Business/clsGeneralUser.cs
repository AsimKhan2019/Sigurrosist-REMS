using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prgRemaxFinalProject.DataSource;

namespace prgRemaxFinalProject.Business
{
    public class clsGeneralUser : clsPerson
    {
        int refGeneralUser;
        string userDescription;
        string userID;

        public int RefGeneralUser
        {
            get
            {
                return refGeneralUser;
            }

            set
            {
                refGeneralUser = value;
            }
        }

        public string UserDescription
        {
            get
            {
                return userDescription;
            }

            set
            {
                userDescription = value;
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

        public clsGeneralUser() : base()
        {
            this.refGeneralUser = 0;
            base.Name = "";
            this.userDescription = "";
            this.userID = "";
        }

        public clsGeneralUser(int refgu, string username, string desc, string userid) : base(username)
        {
            this.refGeneralUser = refgu;
            base.Name = username;
            this.userDescription = desc;
            this.userID = userid;
        }

        public clsGeneralUser Current_User(string userid) // Getting the logged-in-user
        {
            return DataAccess.CurrentGeneralUser(userid);
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
    }
}
