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
                    Console.WriteLine("\n Enter a valid option");
                }
            } while (!valid);
        }

        public static void PopulatePassengerFields()
        {
            List<Passenger.sPassenger> rawPassengers = new List<Passenger.sPassenger>(SearchController.m_NumberOfTickets);
            List<Passenger.sPassenger>  passengers = new List<Passenger.sPassenger>();
            Passenger.sPassenger passenger;
            //foreach (Passenger.sPassenger sPassenger in rawPassengers)
            for (int i = 1; i <= SearchController.m_NumberOfTickets; i ++)
            {
                string name = string.Empty;
                string address = string.Empty;
                string phone = string.Empty;

                Console.WriteLine("\nDetails for passenger " + i);
                Console.WriteLine("Enter full name of the passenger->");
                name = Console.ReadLine();

                Console.WriteLine("Enter address of the passenger->");
                address = Console.ReadLine();

                Console.WriteLine("Enter phone number of the passenger->");
                phone = Console.ReadLine();
                passenger = new Passenger.sPassenger(name, phone, address);

                passengers.Add(passenger);
            }
        }
    }
}
