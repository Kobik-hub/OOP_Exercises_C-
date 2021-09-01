using System;
using System.Collections.Generic;
using System.Text;
using Menu;
namespace MenuTest
{
    class MenuGeneratorDelegates
    {
        public static MainMenu CreateMenu()
        {
            MainMenu mainMenu = new MainMenu();
            List<MenuItem> subMenuItems1 = new List<MenuItem>();
            subMenuItems1.Add(MenuItem.CreateMenuItem("Count Spaces", CountSpaces));
            subMenuItems1.Add(MenuItem.CreateMenuItem("Show Version", ShowVersion));
            MenuItem subMenu1 = MenuItem.CrateSubMenuItem("Version and Spaces", subMenuItems1.ToArray());
            List<MenuItem> subMenuItems2 = new List<MenuItem>();
            subMenuItems2.Add(MenuItem.CreateMenuItem("Show Date", ShowDate));
            subMenuItems2.Add(MenuItem.CreateMenuItem("Show Time", ShowTime));
            MenuItem subMenu2 = MenuItem.CrateSubMenuItem("Show Date/Time", subMenuItems2.ToArray());
            MenuItem rootMenu = MenuItem.CrateSubMenuItem("Main Delegates", subMenu1, subMenu2);
            mainMenu.AddMenuItem(rootMenu);
            return mainMenu;
        }
        public static void ShowDate()
        {
            Console.WriteLine("Date is: {0}", DateTime.Today.ToString("dd/MM/yyyy"));
        }
        public static void ShowTime()
        {
            Console.WriteLine("Time is: {0}", DateTime.Now.ToString("HH:mm:ss"));
        }
        public static void CountSpaces()
        {
            Console.WriteLine("Please enter a sentence");
            string sentence = Console.ReadLine();
            int numberOfSpaces = 0;
            foreach (char c in sentence)
            {
                if (c == ' ')
                {
                    numberOfSpaces += 1;
                }
            }
            Console.WriteLine("Number of spaces: {0}", numberOfSpaces);
        }
        public static void ShowVersion()
        {
            Console.WriteLine("Version: 21.3.4.8933");
        }
    }
}