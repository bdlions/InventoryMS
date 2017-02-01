using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ribbon.Model
{
    class ProductInfoNJ
    {
        private int _id;
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

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

        private double _unitPrice;
        public double UnitPrice
        {
            get
            {
                return this._unitPrice;
            }
            set
            {
                this._unitPrice = value;
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

        private double _purchaseOrderNo;
        public double PurchaseOrderNo
        {
            get
            {
                return this._purchaseOrderNo;
            }
            set
            {
                this._purchaseOrderNo = value;
            }
        }
        

        private string _editProductRow;
        public string EditProductRow
        {
            get
            {
                return _editProductRow;
            }
            set
            {
                _editProductRow = value;

            }
        }

        private string _deleteProductRow;
        public string DeleteProductRow
        {
            get
            {
                return _deleteProductRow;
            }
            set
            {
                _deleteProductRow = value;

            }
        }

    }
}
