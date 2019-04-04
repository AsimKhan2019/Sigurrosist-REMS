using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prgRemaxFinalProject.Business
{
    public class clsUser
    {
        string userID;
        string userPassword;
        string permission;

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

        public string UserPassword
        {
            get
            {
                return userPassword;
            }

            set
            {
                userPassword = value;
            }
        }

        public string Permission
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

        public clsUser()
        {
            this.userID = "";
            this.userPassword = "";
            this.permission = "";
        }
        public clsUser(string userID, string userPassword, string permission)
        {
            this.userID = userID;
            this.userPassword = userPassword;
            this.permission = permission;
        }
    }
}
