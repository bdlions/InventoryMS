using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ribbon.Model
{
    class PurchaseInfoNJ
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

        private SupplierInfoNJ _supplierInfoNJ;
        public SupplierInfoNJ SupplierInfoNJ
        {
            get
            {
                return this._supplierInfoNJ;
            }
            set
            {
                this._supplierInfoNJ = value;
            }
        }

     

        private string _supplier;
        public string SupplierName
        {
            get
            {
                return this._supplier = SupplierFirstName + " "+ SupplierLastName;
            }
            set
            {
                this._supplier = value;
            }
        }

        private string _supplierFirstName;
        public string SupplierFirstName
        {
            get
            {
                return this._supplierFirstName;
            }
            set
            {
                this._supplierFirstName = value;
            }
        }

        private string _supplierLastName;
        public string SupplierLastName
        {
            get
            {
                return this._supplierLastName;
            }
            set
            {
                this._supplierLastName = value;
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

        private string _orderDate;
        public string OrderDate
        {
            get
            {
                return this._orderDate;
            }
            set
            {
                this._orderDate = value;
            }
        }

        private string _orderRemark;
        public string OrderRemark
        {
            get
            {
                return this._orderRemark;
            }
            set
            {
                this._orderRemark = value;
            }
        }

        private long _requestedShipDate;
        public long RequestedShipDate
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

        private long _statusId;
        public long StatusId
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

        private double _price;
        public double Price
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

        private double _quantity;
        public double Quantity
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

        
    }
}
