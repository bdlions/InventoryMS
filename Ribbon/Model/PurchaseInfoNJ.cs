using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ribbon.Model
{
    class PurchaseInfoNJ
    {
        //purchase order no
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
        //purchase info status id
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
        //supplier info of a purchase info
        private SupplierInfoNJ _supplierInfoNJ;
        public SupplierInfoNJ SupplierInfoNJ
        {
            get
            {
                if(_supplierInfoNJ == null)
                {
                    _supplierInfoNJ = new SupplierInfoNJ();
                }
                return this._supplierInfoNJ;
            }
            set
            {
                this._supplierInfoNJ = value;
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


        private string _supplier;
        public string SupplierName
        {
            get
            {
                return this._supplier = SupplierInfoNJ.ProfileInfoNJ.FirstName + " " + SupplierInfoNJ.ProfileInfoNJ.LastName;
            }
            set
            {
                this._supplier = value;
            }
        }
    }
}
