using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParlaFarmaMVCCore.API
{
    public class cls_emailAccount
    {
        public string Address;
        public string DisplayName;
        public cls_emailAccount(string _Address, string _DisplayName)
        {
            Address = _Address;
            DisplayName = _DisplayName;
        }
    }
}
