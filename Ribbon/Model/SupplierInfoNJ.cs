using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ribbon.Model
{

    class SupplierInfoNJ
    {

       

        private string _fname;
        public string SupplierFirstName
        {
            get
            {
                return this._fname;
            }
            set
            {
                this._fname = value;
            }
        }

        private string _lname;
        public string SupplierLastName
        {
            get
            {
                return this._lname;
            }
            set
            {
                this._lname = value;
            }
        }


        private string _supplier;
        public string SupplierName
        {
            get
            {
                return this._supplier = SupplierFirstName + " " + SupplierLastName;
            }
            set
            {
                this._supplier = value;
            }
        }

        private int _supplierUserID;
        public int SupplierUserID
        {
            get
            {
                return this._supplierUserID;
            }
            set
            {
                this._supplierUserID = value;
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


        private string _address1;
        public string Address1
        {
            get
            {
                return this._address1;
            }
            set
            {
                this._address1 = value;
            }
        }

        private string _address2;
        public string Address2
        {
            get
            {
                return this._address2;
            }
            set
            {
                this._address2 = value;
            }
        }

        private string _city;
        public string City
        {
            get
            {
                return this._city;
            }
            set
            {
                this._city = value;
            }
        }

        private string _state;
        public string State
        {
            get
            {
                return this._state;
            }
            set
            {
                this._state = value;
            }
        }

        private string _postalCode;
        public string PostalCode
        {
            get
            {
                return this._postalCode;
            }
            set
            {
                this._postalCode = value;
            }
        }

        private string _country;
        public string Country
        {
            get
            {
                return this._country;
            }
            set
            {
                this._country = value;
            }
        }

    }
}
