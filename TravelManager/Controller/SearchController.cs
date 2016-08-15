using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelManager.Model;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Linq;
using TravelManager.Utilities;
using TravelManager.Views;

namespace TravelManager.Controller
{
    class SearchController
    {
        private static List<string> m_DepartureCities = new List<string>();
        private static List<string> m_DestinationCities = new List<string>();

        public static string m_SelectedDeparture = "";
        public static string m_SelectedDestination = "";
        public static int m_NumberOfTickets = 0;

        public static void AddDepartureCities()
        {
            int count = 0;
            foreach(XmlNode node in DocumentLoader.GetDepartureDocument().GetElementsByTagName(Constants.CITY_XML_NODE_NAME))
            {
                count++;
                m_DepartureCities.Add(node.Attributes[Constants.CITY_XML_ATT_NAME].Value.ToLower());
                Console.WriteLine("\n"+ count + ". " + node.Attributes[Constants.CITY_XML_ATT_NAME].Value);
            }
        }

        public static void SelectDepartureCity()
        {
            string userInput = "";
            bool valid = false;
            do
            {
                userInput = Console.ReadLine().ToLower();
                valid = m_DepartureCities.Contains(userInput);
                if (!valid)
                {
                    Console.WriteLine("Enter a valid city");
                }
                else
                {
                    m_SelectedDeparture = userInput;
                }
            } while (!valid);
        }
        
        public static void AddDestinationCities()
        {
            int count = 0;
            foreach (XmlNode node in DocumentLoader.GetDestinationDocument().GetElementsByTagName(Constants.CITY_XML_NODE_NAME))
            {
                count++;
                m_DestinationCities.Add(node.Attributes[Constants.CITY_XML_ATT_NAME].Value.ToLower());
                Console.WriteLine("\n" + count + ". " + node.Attributes[Constants.CITY_XML_ATT_NAME].Value);
            }
        }

        public static void SelectDestinationCity()
        {
            bool valid = false;
            string userInput = "";
            do
            {
                userInput = Console.ReadLine().ToLower();
                valid = (m_SelectedDeparture != userInput) && m_DestinationCities.Contains(userInput);
                
                if (!valid)
                {
                    Console.WriteLine("Enter a valid city");
                }
                else
                {
                    m_SelectedDestination = userInput;
                }
            } while (!valid);
        }

        public static void SearchForBus()
        {
            foreach (XmlNode node in DocumentLoader.GetBusDocument().GetElementsByTagName(Constants.BUS_XML_NODE_NAME))
            {
                if ((node.Attributes[Constants.BUS_XML_NODE_ATT_DEPARTURE].Value.ToLower() == m_SelectedDeparture) && 
                    (node.Attributes[Constants.BUS_XML_NODE_ATT_DESTINATION].Value.ToLower() == m_SelectedDestination))
                {
                    bool valid = false;
                    do
                    {
                        valid = m_NumberOfTickets <= Int32.Parse(node.Attributes[Constants.BUS_XML_NODE_ATT_SEATS].Value);
                        if (!valid)
                        {
                            Console.WriteLine("\nSeats not available");
                            BuildAndSearch();
                            return;
                        }
                        else
                        {
                            BookingView bookingView = new BookingView();
                            bookingView.OpenView(bookingView);
                        }
                    } while (!valid);
                }
            }
        }

        public static void BuildAndSearch()
        {
            GetTicketCount();

            AddDepartureCities();
            Console.WriteLine("\nEnter Departure city name:");
            SelectDepartureCity();

            AddDestinationCities();
            Console.WriteLine("\nEnter Destination city name:");
            SelectDestinationCity();

            SearchForBus();
        }

        public static void GetTicketCount()
        {
            Console.WriteLine("\nEnter number of tickets");

            bool valid = false;
            do
            {
                Int32.TryParse(Console.ReadLine(), out m_NumberOfTickets);
                valid = m_NumberOfTickets >= 1;
                if (!valid)
                {
                    Console.WriteLine("\nEnter valid Number of tickets");
                }
            } while (!valid);
        }
    }
}
