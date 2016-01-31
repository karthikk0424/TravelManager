using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelManager.Controller;
using System.Xml;
using System.Xml.Linq;
//using System.Web.DynamicData;
//using System.ComponentModel.DataAnnotations;
using System.Globalization;
using TravelManager.Utilities;
using TravelManager.Views;
using TravelManager.Boot;

namespace TravelManager.Bus
{
    class Bus
    {
        public static void Query()
        {
            Console.Clear();
           // int serial = 0;
            string sourceName = string.Empty;
            string destinationName = string.Empty;
            Console.WriteLine("Search bus");
            Console.WriteLine("-------------");
            Console.WriteLine("Please enter Source of your journey: ");
            sourceName = Console.ReadLine();
            Console.WriteLine("Please enter Destination of your journey: ");
            destinationName = Console.ReadLine();

            bool isItemFound = false;
            foreach (XmlNode node in TravelController.GetXMLNodeList())
            {

                if ((!string.IsNullOrEmpty(sourceName) && node.Attributes[Constant.SOURCE_NAME].Value.ToLower().Contains(sourceName)) && (!string.IsNullOrEmpty(destinationName) && node.Attributes[Constant.DESTINATION_NAME].Value.ToLower().Contains(destinationName)))
                {
                    if(node.Attributes[Constant.SOURCE_ROUTE_NUMBER].Value == node.Attributes[Constant.DESTINATION_ROUTE_NUMBER].Value)
                        foreach (XmlNode i in TravelController.GetXMLNodeList())
                        {
                            if (i.Attributes[Constant.SOURCE_ROUTE_NUMBER].Value == i.Attributes[Constant.ROUTE_NUMBER].Value)
                            {
                                isItemFound = true;
                                Console.WriteLine("\nBus Details");
                                Console.WriteLine("-------------");
                                Console.WriteLine("Source Name\t\t: " + i.Attributes[Constant.SOURCE_NAME].Value);
                                Console.WriteLine("Destination Name\t\t: " + i.Attributes[Constant.DESTINATION_NAME].Value);
                                Console.WriteLine("Route Number\t: " + i.Attributes[Constant.ROUTE_NUMBER].Value);
                                Console.WriteLine("Availability\t: " + i.Attributes[Constant.AVAILABLE_SEATS].Value);
                                Console.WriteLine("Bus Fare\t: " + i.Attributes[Constant.BUS_FARE].Value);
                            }
                        }
                    
                }
            }
            if (!isItemFound)
            {
                Console.WriteLine("Oops, No book is found under the given serial number");
            }
        }
    }
}
