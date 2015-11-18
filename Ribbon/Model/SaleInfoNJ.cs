using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ribbon.Model
{
    class SaleInfoNJ
    {
        private string _salesOrderRemark = "Sales Order Remark";
        public string SalesOrderRemark
        {
            get
            {
                return this._salesOrderRemark;
            }
            set
            {
                this._salesOrderRemark = value;
            }
        }
    }
}
