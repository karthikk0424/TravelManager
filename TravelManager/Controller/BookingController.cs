using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelManager.Data;

namespace TravelManager.Controller
{
    class BookingController
    {
        public static string m_UserDecision = string.Empty;
 
        public static void PromptUser()
        {
            Console.WriteLine("\n\u263a Seats are available for the above trip \u263a");
            Console.WriteLine("\nWould you like to book the current selection, type 'y' to continue or 'n' to go back ");

            bool valid = false;
            do
            {
                m_UserDecision = Console.ReadLine().ToLower();
                valid = m_UserDecision == "y" || m_UserDecision == "n";

                if (!valid)
                {
                    Console.WriteLine("\nEnter a valid option");
                }
            } while (!valid);
        }

        public static void PopulatePassengerFields()
        {
          [] passengers = new Passenger[SearchController.m_NumberOfTickets];
        }
    }
}
