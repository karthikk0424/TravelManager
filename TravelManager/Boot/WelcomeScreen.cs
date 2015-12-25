using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelManager.Views;
using TravelManager.Controller;

namespace TravelManager.Boot
{
    class WelcomeScreen
    {
        public virtual void InitWelcomeScreen()
        {
            TravelController.Init();
            Console.WriteLine("\n\nWelcome to Travel Manager\n"); 
            Console.WriteLine("\n\nKindly select the your user type\n");
            Console.WriteLine("1 - Admin");
            Console.WriteLine("2 - Guest User");

            int selection = Utils.OptionSelection(2);

            TravelController.Init();

            switch (selection)
            {
                case 1:
                    Console.WriteLine("\n**** Authentication is required for Admin mode ****");
                    AdminView.Display();  
                    break;
                case 2:
                    MainMenuView.Display();
                    break;
            }

        }
    }
}
