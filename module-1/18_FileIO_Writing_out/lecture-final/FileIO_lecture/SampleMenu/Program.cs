using CLI;
using System;

namespace SampleMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the menu
            MainMenu mainMenu = new MainMenu();
            mainMenu.Run();
        }
    }
}
