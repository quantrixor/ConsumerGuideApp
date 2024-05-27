using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerGuideApp.Model
{
    public class CompanyService
    {
        public int CompanyID { get; set; }
        public int ServiceID { get; set; }
        public virtual Companies Company { get; set; }
        public virtual Services Service { get; set; }
    }

}
