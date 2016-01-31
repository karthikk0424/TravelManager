using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelManager.Utilities;
using TravelManager.Controller;
using TravelManager.Views;
using TravelManager.Boot;
using TravelManager.Bus;

namespace TravelManager.Views
{
    class MainMenuView
    {
        public static void Display()
        {
            Console.WriteLine("Main Menu");

            Console.WriteLine(" 1 - List");
            Console.WriteLine(" 2 - List All");
            Console.WriteLine(" 3 - Back");

            int selection = Utils.OptionSelection(3);

            switch (selection)
            {
                case 1:
                    Bus.Bus.Query();
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
