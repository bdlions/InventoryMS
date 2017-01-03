using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ribbon.Model
{
    class SaleInfoNJ
    {

        private List<ProductInfoNJ> _productList;
        public List<ProductInfoNJ> ProductList
        {
            get
            {
                if (_productList == null)
                {
                    _productList = new List<ProductInfoNJ>();
                }
                return _productList;
            }
            set
            {
                this._productList = value;
            }
        }

        private SaleInfoNJ _customerInfoNJ;
        public SaleInfoNJ CustomerInfoNJ
        {
            get
            {
                return this._customerInfoNJ;
            }
            set
            {
                this._customerInfoNJ = value;
            }
        }


        private string _customerFirstName;
        public string CustomerFirstName
        {
            get
            {
                return this._customerFirstName;
            }
            set
            {
                this._customerFirstName = value;
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
                return this._customerName = _customerFirstName + " " + _customerLastName;
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
        private string _order;
        public string Order
        {
            get
            {
                return this._order;
            }
            set
            {
                this._order = value;
            }
        }

        private string _remark;
        public string Remark
        {
            get
            {
                return this._remark;
            }
            set
            {
                this._remark = value;
            }
        }

        private int _OrderDate;
        public int OrderDate
        {
            get
            {
                return this._OrderDate;
            }
            set
            {
                this._OrderDate = value;
            }
        }

        private int _status;
        public int Status
        {
            get
            {
                return this._status;
            }
            set
            {
                this._status = value;
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
        private string _location;
        public string Location
        {
            get
            {
                return this._location;
            }
            set
            {
                this._location = value;
            }
        }
        private string _requestedShipDate;
        public string RequestedShipDate
        {
            get
            {
                return this._requestedShipDate;
            }
            set
            {
                this._requestedShipDate = value;
            }
        }
        private string _dueDate;
        public string DueDate
        {
            get
            {
                return this._dueDate;
            }
            set
            {
                this._dueDate = value;
            }
        }
        private string _shippedDate;
        public string ShippedDate
        {
            get
            {
                return this._shippedDate;
            }
            set
            {
                this._shippedDate = value;
            }
        }
        private string _total;
        public string Total
        {
            get
            {
                return this._total;
            }
            set
            {
                this._total = value;
            }
        }
        private string _paid;
        public string Paid
        {
            get
            {
                return this._paid;
            }
            set
            {
                this._paid = value;
            }
        }
        private string _balance;
        public string Balance
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
        private double _orderItemDiscount;
        public double OrderItemDiscount
        {
            get
            {
                return this._orderItemDiscount;
            }
            set
            {
                this._orderItemDiscount = value;
            }
        }


    }
}
