using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHospital
{
    [Serializable]
    class HaveBeenFiredException: Exception
    {
        public HaveBeenFiredException(string message) : base(message)
        {

        }
    }
}
