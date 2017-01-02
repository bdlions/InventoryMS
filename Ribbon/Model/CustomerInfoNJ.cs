using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ribbon.Model
{
    class CustomerInfoNJ
    {
        private int _customerUserId;
        public int CustomerUserId
        {
            get
            {
                return this._customerUserId;
            }
            set
            {
                this._customerUserId = value;
            }
        }

        private string _customerFirsrName;
        public string CustomerFirstName
        {
            get
            {
                return this._customerFirsrName;
            }
            set
            {
                this._customerFirsrName = value;
            }
        }

        private string _customerLastName;
        public string CustomerLastName
        {
            get
            {
                return this._customerLastName;

            }
            set
            {
                this._customerLastName = value;
            }
        }

        private string _customerName;
        public string CustomerName
        {
            get
            {
                return this._customerFirsrName + " " + this._customerLastName;
            }
            set
            {
                this._customerName = value;
            }
        }


        private string _phone;
        public string Phone
        {
            get
            {
                return this._phone;
            }
            set
            {
                this._phone = value;
            }
        }

        private string _fax;
        public string Fax
        {
            get
            {
                return this._fax;
            }
            set
            {
                this._fax = value;
            }
        }

        private string _email;
        public string Email
        {
            get
            {
                return this._email;
            }
            set
            {
                this._email = value;
            }
        }

        private double _contact;
        public double Contact
        {
            get
            {
                return this._contact;
            }
            set
            {
                this._contact = value;
            }
        }

        private string _website;
        public string Website
        {
            get
            {
                return this._website;
            }
            set
            {
                this._website = value;
            }
        }


    }
}
