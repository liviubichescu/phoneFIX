using PhoneFix.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneFix.BLL
{
    public class BaseService
    {
        public phonefixDBEntities DbContext = new phonefixDBEntities();
    }
}
