using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prgRemaxFinalProject.Business
{
    public class clsPerson
    {
        string name;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public clsPerson()
        {
            this.name = "";
        }
        public clsPerson(string pname)
        {
            this.name = pname;
        }
    }


}
