using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prgRemaxFinalProject.DataSource;

namespace prgRemaxFinalProject.Business
{
    public class clsClient : clsPerson
    {
        int refClient;
        string phoneNumber;
        string eMail;
        string status;
        int refHouse;

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

        public string EMail
        {
            get
            {
                return eMail;
            }

            set
            {
                eMail = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public int RefHouse
        {
            get
            {
                return refHouse;
            }

            set
            {
                refHouse = value;
            }
        }

        public clsClient() : base()
        {
            this.refClient = 0;
            base.Name = "";
            this.phoneNumber = "";
            this.eMail = "";
            this.status = "";
            this.refHouse = 0;
        }

        public clsClient(int refclient, string cname, string pnumber, string email, string status, int refhouse) : base(cname)
        {
            this.refClient = refclient;
            base.Name = cname;
            this.phoneNumber = pnumber;
            this.eMail = email;
            this.status = status;
            this.refHouse = refhouse;
        }

        public clsClient Searched_Client_by_RefClient(int refclient)
        {
            return DataAccess.SearchClient_by_RefClient(refclient);
        }
    }
}
