using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ribbon.Model
{
    class ProductInfoNJ
    {
        private string _name;
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }


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


        private string _code;
        public string Code
        {
            get
            {
                return this._code;
            }
            set
            {
                this._code = value;
            }
        }

        private long _price;
        public long Price
        {
            get
            {
                return this._price;
            }
            set
            {
                this._price = value;
            }
        }

        private long _quantity;
        public long Quantity
        {
            get
            {
                return this._quantity;
            }
            set
            {
                this._quantity = value;
            }
        }

        private long _discount;
        public long Discount
        {
            get
            {
                return this._discount;
            }
            set
            {
                this._discount = value;
            }
        }

        private int _productId;
        public int ProductId
        {
            get
            {
                return this._productId;
            }
            set
            {
                this._productId = value;
            }
        }
    }
}
