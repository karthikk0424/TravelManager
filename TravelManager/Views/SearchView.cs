using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelManager.Utilities;
using TravelManager.Controller;

namespace TravelManager.Views
{
    class SearchView : View
    {
        public override void OpenView(View view)
        {
            base.OpenView(view);
            Console.WriteLine("\nSearch Menu");
            Console.WriteLine("------------");

            SearchController.BuildAndSearch();

            Console.ReadKey(true);
        }
    }
}
