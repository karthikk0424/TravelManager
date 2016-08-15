using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelManager.Utilities;

namespace TravelManager.Views
{
    class MainMenuView : View
    {
        public override void OpenView(View view)
        {
            base.OpenView(view);

            Console.WriteLine("Main Menu");

            Console.WriteLine(" 1 - Search bus");
            Console.WriteLine(" 2 - Admin mode");
            Console.WriteLine(" 3 - Exit");

            int selection = Utils.OptionSelection(3);

            switch (selection)
            {
                case 1:
                    SearchView searchView = new SearchView();
                    searchView.OpenView(searchView);
                    break;
                case 2:
                    break;
                case 3:
                    CloseView();
                    break;
            }
            Console.ReadKey(true);
        }

        public override void CloseView()
        {
            base.CloseView();
            Environment.Exit(0);
        }
    }
}
