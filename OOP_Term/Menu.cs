using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace PL
{
    internal class Menu : AllControl
    {
        int menuResult;
        protected string[] menuItems = new string[] {"To move across menu use arrows \"UP\" and \"DOWN\", to choose something press \"Enter\" \n (Don't use arrows to end some actions!) ",
                   "1. Work with clients.",
                "2. Work with estates.", "3. Show default list.",
           "4. Show sorted list.", "5. Make proposal list", "6. Search by keyword", "7. Get info about entity", "8. Exit the programm"};
        protected int counter = 0;

        delegate void method();

        

        public static void InputError() => Console.WriteLine("Incorrect data, please try again:");
        public static string ReadItem() => Console.ReadLine();
        public static void WriteItem(string s) => Console.WriteLine(s);
        public int PrintMenu() // repetiang showing function 
        {
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (counter == i)
                    {
                        // front 
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(menuItems[i]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                        Console.WriteLine(menuItems[i]);

                }
                key = Console.ReadKey(); // "moving" through menu
                if (key.Key == ConsoleKey.UpArrow)
                {
                    counter--;
                    if (counter == -1) counter = menuItems.Length - 1;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    counter++;
                    if (counter == menuItems.Length) counter = 0;
                }
            }
            while (key.Key != ConsoleKey.Enter);
            return counter;
        }
        public void ShowMenu()
        {
            do
            {
                Menu menu = this;
                method[] methods = new method[] { Text, Method1, Method2, Method3, Method5, Method6, Method7, Method8, Exit };
                menuResult = menu.PrintMenu();
                methods[menuResult]();
                Console.WriteLine("To continue press any key..");
                Console.ReadKey();
            } while (menuResult != menuItems.Length - 1);
        }

        void Text()
        {
            Console.WriteLine("It is just a text, it does nothing.");
        }
        void Method1()
        {
            Console.WriteLine(Menu.WorkWithClient());
        }
        void Method2()
        {
            Console.WriteLine(Menu.WorkWithEstate());
        }
        void Method3()
        {
            Console.WriteLine(Menu.ShowDefaultList()); 
        }
        void Method5()
        {
            Console.WriteLine(Menu.ShowSortedList());
        }
        void Method6()
        {
            Console.WriteLine(Menu.MakeProposalList());
        }
        void Method7()
        {
            Console.WriteLine(Menu.SearchByKeyword());
        }
        void Method8()
        {
          Console.WriteLine(Menu.GetEsp());
        }
        static void Exit()
        {
            Console.WriteLine("Program is ending its work");
            Environment.Exit(1);
        }
    }
}
