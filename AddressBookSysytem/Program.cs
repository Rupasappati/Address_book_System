using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class AddressBookMain
    {

        internal static Dictionary<string, Contacts> addressBookDict = new Dictionary<string, Contacts>();

        internal static void Main()
        {
            Console.WriteLine("Welcome to Address Book Program");
            Console.WriteLine("Enter the Address Book Name or Enter Name of the saved Address Book");
            string addressBookName = Console.ReadLine();
            WorkingOnAddressBook.AddressBook(addressBookName);

        }

    }
}
