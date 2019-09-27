using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager
{
    public class Contact
    {
        public string ID;
        public string Name;
        public string Group;
        public string Num;
        public string Remark;

        public override bool Equals(object obj)
        {

            return base.Equals(obj);
        }
    }
}
