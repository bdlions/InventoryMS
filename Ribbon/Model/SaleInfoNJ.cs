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

        //sale info customer user id
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

        //sale info sale date
        private string _saleDate;
        public string SaleDate
        {
            get
            {
                return this._saleDate;
            }
            set
            {
                this._saleDate = value;
            }
        }


        //sale info discount
        private double _discount;
        public double Discount
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
                if(_customerInfoNJ == null)
                {
                    _customerInfoNJ = new CustomerInfoNJ();
                }
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

        private string _customerName;
        public string CustomerName
        {
            get
            {
                return this._customerName = CustomerInfoNJ.ProfileInfoNJ.FirstName + " " + CustomerInfoNJ.ProfileInfoNJ.LastName;
            }
            set
            {
                this._customerName = value;
            }
        }

    }
}
