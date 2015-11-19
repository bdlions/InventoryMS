using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ribbon.Model
{
    class PurchaseInfoNJ
    {

        private string _supplier;
        public string Supplier
        {
            get
            {
                return this._supplier;
            }
            set
            {
                this._supplier = value;
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

        private int _requestedShipDate;
        public int RequestedShipDate
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

        
    }
}
