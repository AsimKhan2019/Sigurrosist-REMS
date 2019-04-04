using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prgRemaxFinalProject.Business
{
    public class clsSales
    {
        int refSales;
        int refHouse;
        int refClient;
        int refAgent;
        string description;
        DateTime salesDate;

        public int RefSales
        {
            get
            {
                return refSales;
            }

            set
            {
                refSales = value;
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

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public DateTime SalesDate
        {
            get
            {
                return salesDate;
            }

            set
            {
                salesDate = value;
            }
        }

        public clsSales()
        {
            this.RefSales = 0;
            this.refHouse = 0;
            this.refClient = 0;
            this.refAgent = 0;
            this.description = "";
            this.salesDate = DateTime.MinValue;
        }
        public clsSales(int refSales, int refHouse, int refClient, int refAgent, string description, DateTime salesDate)
        {
            this.refSales = refSales;
            this.refHouse = refHouse;
            this.refClient = refClient;
            this.refAgent = refAgent;
            this.description = description;
            this.salesDate = salesDate;
        }
    }
}
