using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class AddressBookMain
    {
        public static List<Contacts> listCon = new List<Contacts>();
        static void Main()
        {
            Console.WriteLine("Welcome to Address Book Program");
            Calling.CallingAddressBook();
        }

    }

}
