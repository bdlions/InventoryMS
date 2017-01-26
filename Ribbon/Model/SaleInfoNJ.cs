using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ribbon.Model
{
    class SaleInfoNJ
    {
        //sale order no
        private string _orderNo;
        public string OrderNo
        {
            get
            {
                return this._orderNo;
            }
            set
            {
                this._orderNo = value;
            }
        }

        //sale info status id
        private int _statusId;
        public int StatusId
        {
            get
            {
                return this._statusId;
            }
            set
            {
                this._statusId = value;
            }
        }

        //purchase remarks
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

        //customer info of a sale info
        private CustomerInfoNJ _customerInfoNJ;
        public CustomerInfoNJ CustomerInfoNJ
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

        ObservableCollection<ProductInfoNJ> _productList;
        public ObservableCollection<ProductInfoNJ> ProductList
        {
            get
            {
                if (_productList == null)
                {
                    _productList = new ObservableCollection<ProductInfoNJ>();
                }
                return _productList;
            }
            set
            {
                this._productList = value;
            }
        }

        //private List<ProductInfoNJ> _productList;
        //public List<ProductInfoNJ> ProductList
        //{
        //    get
        //    {
        //        if (_productList == null)
        //        {
        //            _productList = new List<ProductInfoNJ>();
        //        }
        //        return _productList;
        //    }
        //    set
        //    {
        //        this._productList = value;
        //    }
        //}


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
