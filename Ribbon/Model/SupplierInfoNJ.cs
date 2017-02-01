using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ribbon.Model
{

    class SupplierInfoNJ
    {
        private ProfileInfoNJ _profileInfoNJ;
        public ProfileInfoNJ ProfileInfoNJ
        {
            get
            {
                if (_profileInfoNJ == null)
                {
                    _profileInfoNJ = new ProfileInfoNJ();
                }
                return this._profileInfoNJ;
            }
            set
            {
                this._profileInfoNJ = value;
            }
        }

        private string _remarks;
        public string Remarks
        {
            get
            {
                return this._remarks;
            }
            set
            {
                this._remarks = value;
            }
        }

       

        //----------------------------------Implement later ------------------------------//


        private double _balance;
        public double Balance
        {
            get
            {
                return this._balance;
            }
            set
            {
                this._balance = value;
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
