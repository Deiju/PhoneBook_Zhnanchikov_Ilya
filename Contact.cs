using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Contact
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public Contact (string name,string phone)
        {
            Name = name;
            Phone = phone;
        }

        public string GetInfo (string name,string phone)
        {
            return $"{name},{phone}";
        }
    }
}