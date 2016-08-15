using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelManager.Utilities
{
    static class Constants
    {
        //Departure data
        public const string DEPARTURE_XML_FILENAME = "departure.xml";
        
        //City
        public const string CITY_XML_ROOT_NAME = "Cities";
        public const string CITY_XML_NODE_NAME = "City";
        public const string CITY_XML_ATT_NAME = "CityName";

        //Departure data
        public const string DESTINATION_XML_FILENAME = "destination.xml";

        //Bus data
        public const string BUS_XML_FILENAME = "bus.xml";
        public const string BUS_ROOT_NAME = "Buses";
        public const string BUS_XML_NODE_NAME = "Bus";
        
        public const string BUS_XML_NODE_ATT_DEPARTURE = "Departure";
        public const string BUS_XML_NODE_ATT_DESTINATION = "Destination";
        public const string BUS_XML_NODE_ATT_BUS_NUMBER = "BusNumber";
        public const string BUS_XML_NODE_ATT_SEATS = "Seats";
        
    }
}
