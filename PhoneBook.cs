using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class PhoneBook
    {
        private List<Contact> contacts;
        public PhoneBook ()
        {
            contacts = new List<Contact>( );
        }
        public void CreateContact (Contact contact)
        {
            contacts.Add(contact);
        }
        public void RemoveContact (Contact contact)
        {
            contacts.Remove(contact);          
        }
        public void RemoveContactByItems (string name)
        {
            Contact contact = contacts.Find(c => c.Name == name);
            if(contact!=null)
            {
                contacts.Remove(contact);
            }
        }
        public List<Contact> GetContact ()
        {
            return contacts;
        }        
        public Contact FindByName (string name)
        {
            foreach ( Contact contacts in contacts )
            {
                if ( contacts.Name.Contains(name))
                {
                    return contacts;
                }
            }
            return null;
        }
        public bool Found(Contact VerifableContact)
        {
            bool NotFound = true;

            foreach (Contact Contact in contacts)
            {
                if (Contact.Phone.Contains(VerifableContact.Phone))
                {
                    NotFound = false;
                    break;
                }
            }
            return NotFound;
        }
    }

}
