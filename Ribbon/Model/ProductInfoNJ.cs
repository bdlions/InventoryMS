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
    }
}
