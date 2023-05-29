using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class PhoneBookLoader
    {
        public static void Load (PhoneBook phoneBook, string fileName)
        {
            if ( File.Exists(fileName) )
            {
                string [ ] line = File.ReadAllLines(fileName);
                foreach ( string lines in line )
                {
                    string [ ] load = lines.Split(';');
                    if ( load.Length == 2 )
                    {
                        string name = load [ 0 ];
                        string phone = load [ 1 ];
                        phoneBook.CreateContact(new Contact(name,phone));
                    }
                }
            }
        }
        public static void Save (ListBox listBox, string fileName)
        {
            StreamWriter write = new StreamWriter(fileName);
            for ( int i=0;i<listBox.Items.Count;i++ )
            {
                write.WriteLine(listBox.Items[i]);
            }
            write.Close( );
        }
    }

}
