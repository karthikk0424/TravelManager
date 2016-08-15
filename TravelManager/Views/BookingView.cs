using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelManager.Controller;

namespace TravelManager.Views
{
    class BookingView : View
    {
        public override void OpenView(View view)
        {
            base.OpenView(view);

            Console.WriteLine("\nBooking Menu");
            Console.WriteLine("\n---------------");

            BookingController.PromptUser();

            if (BookingController.m_UserDecision.Equals("y"))
            {
                BookingController.PopulatePassengerFields(); 

                // TODO Store passenger details in SQL or XML and prepare passenger ticket
            }
            else
            {
                base.CloseView();
            }
        }
    }
}
