using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelManager.Views;
using TravelManager.Controller;

namespace TravelManager
{
    /*
     * This is the entry point of the application,
     * Initialize modules and managers here.
     */
    class Launcher
    {
        static void Main(string[] args)
        {
            Console.Title = "Travel Manager";
            string consoleName = "++++ Travel Manager Console ++++" + Environment.NewLine;
            Console.WriteLine(consoleName);

            Init();
            Launch();

            Console.ReadKey(true);
        }

        private static void Init()
        {
            ScheduleController.Init();  
        }

        private static void Launch()
        {
            MainMenuView mainMenuView = new MainMenuView();
            mainMenuView.OpenView(mainMenuView);
        }
    }
}
