using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class AddressBookManagement
    {
        //Defining the list
        List<Contacts> contactList;
        Dictionary<string, List<Contacts>> addressBookDictionary;

        //Defining constructor
        public AddressBookManagement()
        {
            contactList = new List<Contacts>();
            addressBookDictionary = new Dictionary<string, List<Contacts>>();
        }

        public void AddContactDetail(string firstName, string lastName, string address, string city, string state, int zipcode, long phoneNumber, string email)
        {
            Contacts personDetail = new Contacts(firstName, lastName, address, city, state, zipcode, phoneNumber, email);
            contactList.Add(personDetail);
        }

        //Adding New Contact
        public void AddNewContact()
        {
            Console.WriteLine("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter the Address: ");
            string address = Console.ReadLine();
            Console.WriteLine("Enter the City: ");
            string city = Console.ReadLine();
            Console.WriteLine("Enter the State: ");
            string state = Console.ReadLine();
            Console.WriteLine("Enter the Zipcode: ");
            int zipcode = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Phone Number: ");
            long phoneNumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter your Email-ID: ");
            string email = Console.ReadLine();

            AddContactDetail(firstName, lastName, address, city, state, zipcode, phoneNumber, email);
            ViewContact();
        }

        //Viewing Contacts
        public void ViewContact()
        {
            int count = 1;
            foreach (var contact in contactList)
            {
                Console.WriteLine("First Name: " + contact.firstName);
                Console.WriteLine("Last Name: " + contact.lastName);
                Console.WriteLine("Address: " + contact.address);
                Console.WriteLine("City: " + contact.city);
                Console.WriteLine("State: " + contact.state);
                Console.WriteLine("ZipCode: " + contact.zipcode);
                Console.WriteLine("Phone Number: " + contact.phoneNumber);
                Console.WriteLine("Email ID: " + contact.email);
                count++;
                // Console.WriteLine("===========================================");
            }
        }

        //Edit Contact Details
        public void EditContact(string input)
        {
            for (int i = 0; i < contactList.Count; i++)
            {
                if (contactList[i].firstName == input)
                {
                    Console.WriteLine("\nChoose the field you want to edit " +
                        "\n1.)First Name\n2.)Last Name\n3.)Address\n4.)City\n5.)State\n6.)ZipCode\n7.)Phone Number\n8.)EmailID\n");
                    int editDetails = Convert.ToInt32(Console.ReadLine());
                    switch (editDetails)
                    {
                        case 1:
                            Console.WriteLine("Edit First Name: ");
                            contactList[i].firstName = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Edit Last Name: ");
                            contactList[i].lastName = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Enter New Address: ");
                            contactList[i].address = Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Edit City: ");
                            contactList[i].city = Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("Edit State: ");
                            contactList[i].state = Console.ReadLine();
                            break;
                        case 6:
                            Console.WriteLine("Edit ZipCode: ");
                            contactList[i].zipcode = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 7:
                            Console.WriteLine("Edit Phone Number: ");
                            contactList[i].phoneNumber = Convert.ToInt64(Console.ReadLine());
                            break;
                        case 8:
                            Console.WriteLine("Edit Email-ID: ");
                            contactList[i].email = Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Invalid Input");
                            break;
                    }
                }
                else
                    Console.WriteLine("Person {0} is not in the List!", input);
            }
            ViewContact();
        }

        public void DeletePersonContact(string firstName, string lastName)
        {
            for (int index = 0; index < contactList.Count; index++)
            {
                if (contactList[index].firstName == firstName && contactList[index].lastName == lastName)
                {
                    Console.WriteLine("Contact {0} {1} Deleted Successfully from Address Book.", contactList[index].firstName, contactList[index].lastName);
                    contactList.RemoveAt(index);
                    ViewContact();
                }
                else
                    Console.WriteLine("Person {0} {1} do not exists.", firstName, lastName);
            }
        }

        //Add Address Book
        public void AddNewAddressBook()
        {
            //Creating new dictionary
            Dictionary<string, AddressBookManagement> addressBookDictionary = new Dictionary<string, AddressBookManagement>();
            Console.WriteLine("Number of books to be added :  ");
            int numberOfBooks = Convert.ToInt32(Console.ReadLine());
            while (numberOfBooks > 0)
            {
                Console.WriteLine("Enter the name of Address Book :");
                string addBookName = Console.ReadLine();
                if (addressBookDictionary.ContainsKey(addBookName))
                {
                    Console.WriteLine("Address Book Already Exists");
                }
                else
                {
                    AddressBookManagement books = new AddressBookManagement();
                    books.AddNewContact();
                }
                foreach (KeyValuePair<string, AddressBookManagement> item in addressBookDictionary)
                {
                    Console.WriteLine($"key:{item.Key} value:{item.Value}");
                }
                numberOfBooks--;
            }
        }

        public void SearchPerson()
        {
            Console.WriteLine("enter the city or state name");
            string city = Console.ReadLine();
            int found = 0;
            foreach (KeyValuePair<string, List<Contacts>> user in addressBookDictionary)
            {
                foreach (Contacts contact in user.Value)
                {
                    if (contact.city == city || contact.state == city)
                    {
                        Console.WriteLine(contact.firstName);
                        found = 1;
                    }
                }
            }
            if (found == 0)
                Console.WriteLine("No record found");
        }

        public void ViewPerson()
        {
            Console.WriteLine("enter the city or state name");
            string city = Console.ReadLine();
            foreach (KeyValuePair<string, List<Contacts>> user in addressBookDictionary)
            {
                foreach (Contacts contact in user.Value)
                {
                    if (contact.city == city || contact.state == city)
                    {
                        Console.WriteLine("FirstName: " + contact.firstName);
                        Console.WriteLine("LastName: " + contact.lastName);
                        Console.WriteLine("City: " + contact.city);
                        Console.WriteLine("State: " + contact.state);
                        Console.WriteLine("Address: " + contact.address);
                        Console.WriteLine("zipCode: " + contact.zipcode);
                        Console.WriteLine("Email: " + contact.email);
                        Console.WriteLine("PhoneNo: " + contact.phoneNumber);
                    }
                }
            }
        }

    }
}
