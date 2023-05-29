using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 :Form
    {
        public Form1 ()
        {
            InitializeComponent( );
            Load("1.txt");
        }
        private static PhoneBook book = new PhoneBook( );
        string message = "";
        private void Form1_Load (object sender, EventArgs e)
        {

        }

        private void button1_Click (object sender, EventArgs e)
        {
            string name = textBox2.Text;
            string phone=textBox1.Text;
            message= CheckName(textBox2.Text);
            message = CheckPhone(textBox1.Text);
            if ( textBox1.Text != "" && textBox2.Text != "" && message=="")
            {
                Contact Contact = new Contact(name, phone);
                bool Found = book.Found(Contact);
                if (Found == true)
                {
                    book.CreateContact(Contact);
                    listBox1.Items.Add(Contact.Name + ";" + Contact.Phone);
                }
                else
                {
                    MessageBox.Show("Контакт с таким номером уже существует.");
                }
                
                
            }
        }

        private void button4_Click (object sender, EventArgs e)
        {
            Display( );
        }
        public void Load (string filename)
        {
            PhoneBookLoader.Load(book, filename);
            Display( );
        }        
        private void button5_Click (object sender, EventArgs e)
        {
            Application.Exit( );
        }
        public void Display ()
        {
            listBox1.Items.Clear( );
            foreach ( Contact contact in book.GetContact( ))
            {
                listBox1.Items.Add(contact.Name+";"+contact.Phone);
            }
        }
        
        private void button3_Click (object sender, EventArgs e)
        {
            PhoneBookLoader.Save(listBox1, "1.txt");
        }

        private void button2_Click (object sender, EventArgs e)
        {            
            if(listBox1.SelectedIndex!=1)
            {
                string selectcontact = listBox1.SelectedItem.ToString( );
                book.RemoveContactByItems(selectcontact);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            PhoneBookLoader.Save(listBox1, "1.txt");
        }

        private void button6_Click (object sender, EventArgs e)
        {
            if(textBox5.Text!="")
            {
                SearchName(textBox5.Text);
            }
            else
            {
                SearchPhone(textBox3.Text);
            }
        }
        public void SearchName (string name)
        {
            listBox1.Items.Clear( );
            foreach ( Contact contact in book.GetContact() )
            {
                if ( contact.Name.Contains(name) )
                {
                    listBox1.Items.Add(contact.Name + ";" + contact.Phone); 
                }
            }
        }
        public void SearchPhone (string phone)
        {
            listBox1.Items.Clear( );
            foreach ( Contact contact in book.GetContact( ) )
            {
                if ( contact.Phone.Contains(phone) )
                {
                    listBox1.Items.Add(contact.Name + ";" + contact.Phone);
                }
            }
        }
        static string CheckName (string TextName)
        {
            string message = "";

            if ( TextName == "" )
            {
                message = "er";
                MessageBox.Show("Поле для ввода пустые.");
            }
            else
            {
                foreach ( char symbol in TextName )
                {
                    if ( !char.IsLetter(symbol) && symbol != ' ' )
                    {
                        message = "er";
                        MessageBox.Show("Поле имя может содержать только буквы.");
                        break;
                    }
                    
                }
            }
            return message;
        }

        static string CheckPhone (string TextPhone)
        {
            string message = "";

            if ( TextPhone == "" )
            {
                message = "er";
                MessageBox.Show("Поле для ввода номера телефона пустые.");
            }
            else
            {
                if ( message == "" )
                {
                    foreach ( char symbol in TextPhone )
                    {
                        if ( !char.IsDigit(symbol)&& TextPhone[0]!='(' && TextPhone [ 4 ] != ')'&& TextPhone [ 8 ] != '-'&& TextPhone [ 8 ] != '-'&& TextPhone [ 11 ] != '-')
                        {
                            MessageBox.Show("Поле для ввода номера телефона может содержать только цифры,'()' и '-'.");
                            message = "er";
                            break;
                        }

                    }
                }

                if ( message == "" )
                {
                    if ( TextPhone.Length < 14 || TextPhone.Length > 14 )
                    {
                        MessageBox.Show("Некорректное количество символов в номере телефона для сохранения.");
                        message = "er";
                    }

                }
            }
            return message;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
    

