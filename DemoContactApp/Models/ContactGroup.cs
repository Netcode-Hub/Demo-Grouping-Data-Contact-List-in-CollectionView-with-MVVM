using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoContactApp.Models;

namespace DemoContactApp.Models
{
    public class ContactGroup : List<Models.Contact>
    {
        public string Name { get; private set; }
        public ContactGroup(string name, List<Models.Contact> MyGroupContacts) : base(MyGroupContacts)
        {
            Name = name;
        }
    }
}
