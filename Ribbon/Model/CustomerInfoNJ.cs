using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ribbon.Model
{
    class CustomerInfoNJ
    {
        private ProfileInfoNJ _profileInfoNJ;
        public ProfileInfoNJ ProfileInfoNJ
        {
            get
            {
                if (_profileInfoNJ == null)
                {
                    _profileInfoNJ = new ProfileInfoNJ();
                }
                return this._profileInfoNJ;
            }
            set
            {
                this._profileInfoNJ = value;
            }
        }

        //----------------------------------Implement later ------------------------------//

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

    }
}
