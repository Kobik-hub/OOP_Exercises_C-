using Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuTest
{
    class MenuGeneratorInterfaces
    {
        public static MainMenu CreateMenu()
        {
            MainMenu mainMenu = new MainMenu();
            List<MenuItem> subMenuItems1 = new List<MenuItem>();
            subMenuItems1.Add(MenuItem.CreateMenuItem("Count Spaces", new CountSpaces()));
            subMenuItems1.Add(MenuItem.CreateMenuItem("Show Version", new ShowVersion()));
            MenuItem subMenu1 = MenuItem.CrateSubMenuItem("Version and Spaces", subMenuItems1.ToArray());
            List<MenuItem> subMenuItems2 = new List<MenuItem>();
            subMenuItems2.Add(MenuItem.CreateMenuItem("Show Date", new ShowDate() as IMenuItemObserver));
            subMenuItems2.Add(MenuItem.CreateMenuItem("Show Time", new ShowTime() as IMenuItemObserver));
            MenuItem subMenu2 = MenuItem.CrateSubMenuItem("Show Date/Time", subMenuItems2.ToArray());
            MenuItem rootMenu = MenuItem.CrateSubMenuItem("Main Interfaces", subMenu1, subMenu2);
            mainMenu.AddMenuItem(rootMenu);
            return mainMenu;
        }
    }
    class ShowDate : IMenuItemObserver
    {
        public void ItemChosen()
        {
            Console.WriteLine("Date is: {0}", DateTime.Today.ToString("dd/MM/yyyy"));
        }
    }
    class ShowTime : IMenuItemObserver
    {
        public void ItemChosen()
        {

            Console.WriteLine("Time is: {0}", DateTime.Now.ToString("HH:mm:ss"));
        }
    }
    class CountSpaces : IMenuItemObserver
    {
        public void ItemChosen()
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
    }
    class ShowVersion : IMenuItemObserver
    {
        public void ItemChosen()
        {
            Console.WriteLine("Version: 21.3.4.8933");
        }
    }
}
