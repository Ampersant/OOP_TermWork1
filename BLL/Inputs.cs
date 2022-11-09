using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL;


namespace BLL
{
    public class Inputs
    {
        // client side
        public static string InputFirstName() // public because using while NUnit testing 
        {
            Console.WriteLine($"Enter Name(example Adam):");
            string data = Console.ReadLine();
            Exception validation = new Exception(data, @"^[A-Z]{1}[a-z]*$");
            return validation.Check();
        }
        public static string InputLastName() // public because using while NUnit testing
        {
            Console.WriteLine($"Enter Surname(example Green):");
            string data = Console.ReadLine();
            Exception validation = new Exception(data, @"^[A-Z]{1}[a-z]*$");
            return validation.Check();
        }
        public static string InputBankID() // public because using while NUnit testing 
        {
            Console.WriteLine("Enter the IBAN of the bank account (2 up letters & 8 digits):");
            string data = Console.ReadLine();
            Exception validation = new Exception(data, @"^[A-Z]{2}\d{8}$");
            return validation.Check();
        }
        internal static int InputUserID(string s = null)
        {
            if (s == null)
            {
                Console.WriteLine("Enter user ID (5 digits):");
                string data = Console.ReadLine();
                Exception validation = new Exception(data, @"^\d{5}$");
                return int.Parse(validation.Check());
            }
            else
            {
                Console.WriteLine(s);
                Console.WriteLine("Enter user ID (5 digits):");
                string data = Console.ReadLine();
                Exception validation = new Exception(data, @"^\d{5}$");
                return int.Parse(validation.Check());
            }

        }
        // estate side 
        internal static string InputEstateType()
        {
            Console.WriteLine($"1 - 1-room flat || 2 - 2-rooms flat || 3 - 3-rooms flat || 4 - Mansion ");
            string data = Console.ReadLine();
            Exception validation = new Exception(data, @"[1-4]{1}$");
            string s = validation.Check();
            if (s == "1")
            {
                return "1-room flat";
            }
            else if (s == "2")
            {
                return "2-room flat";
            }
            else if (s == "3")
            {
                return "3-rooms flat";
            }
            else
            {
                return "Mansion";
            }

        }
        internal static int InputEstateID(string s = null)
        {
            if (s == null)
            {
                Console.WriteLine("Enter Estate ID (5 digits):");
                string data = Console.ReadLine();
                Exception validation = new Exception(data, @"^\d{5}$");
                return int.Parse(validation.Check());
            }
            else
            {
                Console.WriteLine(s);
                Console.WriteLine("Enter Estate ID (5 digits):");
                string data = Console.ReadLine();
                Exception validation = new Exception(data, @"^\d{5}$");
                return int.Parse(validation.Check());
            }
        }

        internal static double InputEstateCost()
        {
            Console.WriteLine("Enter the cost of estate (###+.##+):");
            string data = Console.ReadLine();
            Exception validation = new Exception(data, @"\d{3,6}\.\d{2,6}");
            return double.Parse(validation.Check());
        }
        internal static double InputEstateSquare()
        {
            Console.WriteLine("Enter the sqaure of estate (###+.##+):");
            string data = Console.ReadLine();
            Exception validation = new Exception(data, @"\d{3,6}\.\d{2,6}");
            return double.Parse(validation.Check());
        }
        // logic
        internal static string InputDo()
        {
            Console.WriteLine($"1 - Create || 2 - Delete || 3 - Edit");
            string data = Console.ReadLine();
            Exception validation = new Exception(data, @"^[1-3]{1}$");
            string s = validation.Check();
            if (s == "1")
            {
                return "Create";
            }
            else if (s == "2")
            {
                return "Delete";
            }
            else
            {
                return "Edit";
            }
        }
        // list 
        internal static string InputWhatList()
        {
            Console.WriteLine($"1 - Client List || 2 - Estate List");
            string data = Console.ReadLine();
            Exception validation = new Exception(data, @"[1-2]{1}$");
            return validation.Check();
        }
        internal static string InputClientSort()
        {
            Console.WriteLine($"1 - By Name || 2 - By Surname || 3 - By first digit of Bank acc");
            string data = Console.ReadLine();
            Exception validation = new Exception(data, @"^[1-3]{1}$");
            return validation.Check();
        }
        internal static string InputEstateSort()
        {
            Console.WriteLine($"1 - By Type || 2 - By Cost");
            string data = Console.ReadLine();
            Exception validation = new Exception(data, @"[1-2]{1}$");
            return validation.Check();
        }
        internal static string InputWhatProps()
        {
            Console.WriteLine($"1 - With filtration(by cost & type) || 2 - Without filtration(by client preference)");
            string data = Console.ReadLine();
            Exception validation = new Exception(data, @"[1-2]{1}$");
            return validation.Check();
        }
        // proposal list
        internal static double InputBoundsHCost()
        {
            Console.WriteLine("Enter the !hieghest! cost of estate (###+.##+):");
            string data = Console.ReadLine();
            Exception validation = new Exception(data, @"\d{3,6}\.\d{2,6}");
            return double.Parse(validation.Check());
        }
        internal static double InputBoundsLCost()
        {
            Console.WriteLine("Enter the !lowest! cost of estate (###+.##+):");
            string data = Console.ReadLine();
            Exception validation = new Exception(data, @"\d{3,6}\.\d{2,6}");
            return double.Parse(validation.Check());
        }
        internal static string InputWhatAgree(string obj)
        {
            Console.WriteLine(obj);
            Console.WriteLine("Are you like this variant?");
            Console.WriteLine($"1 - Yes, buy it! || 2 - No, go next..");
            string data = Console.ReadLine();
            Exception validation = new Exception(data, @"[1-2]{1}$");
            return validation.Check();
        }
        // keyword search
        internal static string InputTypeSearch()
        {
            Console.WriteLine($"1 - Search for clients || 2 - Search for estate || 3 - Search for all");
            string data = Console.ReadLine();
            Exception validation = new Exception(data, @"^[1-3]{1}$");
            return validation.Check();
        }
        internal static string InputKeywordSearch()
        {
            Console.WriteLine($"Please, enter the keyword to search the object...");
            string data = Console.ReadLine();
            Exception validation = new Exception(data, @"^[\w\s]");
            return validation.Check();
        }
        internal static string InputWhatToEditCl()
        {

            var props = typeof(Client).GetProperties();
            int count = 0;
            foreach (var item in props)
            {
                count++;
                Console.WriteLine($"{count}. {item.Name}");
            }
            string data = Console.ReadLine();
            Exception validation = new Exception(data, @"^[1-6]{1}$");
            return validation.Check();
        }
        // edit 
        internal static string InputWhatToEditEs()
        {

            var props = typeof(Estate).GetProperties();
            int count = 0;
            foreach (var item in props)
            {
                count++;
                Console.WriteLine($"{count}. {item.Name}");
            }
            string data = Console.ReadLine();
            Exception validation = new Exception(data, @"^[1-5]{1}$");
            return validation.Check();
        }
    }
}
