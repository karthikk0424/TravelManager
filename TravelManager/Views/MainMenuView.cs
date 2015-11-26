using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelManager.Utilities;

namespace TravelManager.Views
{
    class MainMenuView
    {
        public static void Display()
        {
            Console.WriteLine("Main Menu");

            Console.WriteLine(" 1 - Query");
            Console.WriteLine(" 2 - List All");
            Console.WriteLine(" 3 - Back");

            int selection = Utils.OptionSelection(3);

            switch (selection)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
            Console.ReadKey(true);
        }
    }
}
