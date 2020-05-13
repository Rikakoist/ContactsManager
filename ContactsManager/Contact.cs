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

        public Contact()
        {

        }

        public Contact(string iD, string name, string group, string num, string remark)
        {
            ID = iD;
            Name = name;
            Group = group;
            Num = num;
            Remark = remark;
        }

        public override bool Equals(object obj)
        {

            return base.Equals(obj);
        }
    }
}
