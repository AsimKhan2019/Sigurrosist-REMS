using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prgRemaxFinalProject.Business
{
    public class clsHouse
    {
        int refHouse;
        string address;
        int area;
        decimal price;
        int floor;
        int numRoom;
        int numBath;
        bool accessible;
        string status;

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

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public int Area
        {
            get
            {
                return area;
            }

            set
            {
                area = value;
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public int Floor
        {
            get
            {
                return floor;
            }

            set
            {
                floor = value;
            }
        }

        public int NumRoom
        {
            get
            {
                return numRoom;
            }

            set
            {
                numRoom = value;
            }
        }

        public int NumBath
        {
            get
            {
                return numBath;
            }

            set
            {
                numBath = value;
            }
        }

        public bool Accessible
        {
            get
            {
                return accessible;
            }

            set
            {
                accessible = value;
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

        public clsHouse()
        {
            this.refHouse = 0;
            this.address = "";
            this.area = 0;
            this.price = 0;
            this.floor = 0;
            this.numRoom = 0;
            this.numBath = 0;
            this.accessible = false;
            this.status = "";
        }
        public clsHouse(int refHouse, string address, int area, decimal price, int floor, int numRoom, int numBath, bool accessible, string status)
        {
            this.refHouse = refHouse;
            this.address = address;
            this.area = area;
            this.price = price;
            this.floor = floor;
            this.numRoom = numRoom;
            this.numBath = numBath;
            this.accessible = accessible;
            this.status = status;
        }
    }
}
