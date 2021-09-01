using System;
using Menu;
namespace MenuTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu menuWithInterface = MenuGeneratorInterfaces.CreateMenu();
            menuWithInterface.Show();
        }
    }
}
