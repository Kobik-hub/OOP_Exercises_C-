using System;
using Menu;

namespace MenuTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu menuWithDelegate = MenuGeneratorDelegates.CreateMenu();
            menuWithDelegate.Show();
        }
    }
}
