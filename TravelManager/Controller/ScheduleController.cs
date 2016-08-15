using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelManager.Data;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.IO;
using System.Xml.Linq;
using TravelManager.Utilities;

namespace TravelManager.Controller
{
    class ScheduleController
    {
        private List<string> m_SourceNames = new List<string>();
        private List<string> m_DestinationNames = new List<string>();

        public static void InitBuses()
        {
            bool createDefaultData = false;
            if (!File.Exists(Constants.DEPARTURE_XML_FILENAME))
            {
                //File does not exit, create default items
                string[] departureNames = new string[] { "Chennai", "Salem", "Coimbatore", "Trichy", "Velore" };
                CreateDefaultData(Constants.DEPARTURE_XML_FILENAME, 
                    Constants.CITY_XML_ROOT_NAME, 
                    Constants.CITY_XML_NODE_NAME,
                    Constants.CITY_XML_ATT_NAME, departureNames);
                createDefaultData = true;
            }

            if (!File.Exists(Constants.DESTINATION_XML_FILENAME))
            {
                //File does not exit, create default items
                string[] departureNames = new string[] { "Chennai", "Salem", "Coimbatore", "Trichy", "Velore" };
                CreateDefaultData(Constants.DESTINATION_XML_FILENAME,
                    Constants.CITY_XML_ROOT_NAME,
                    Constants.CITY_XML_NODE_NAME,
                    Constants.CITY_XML_ATT_NAME, departureNames);
                createDefaultData = true;
            }

            XmlDocument sourceDocument = new XmlDocument();
            sourceDocument.Load(Constants.DEPARTURE_XML_FILENAME);

            XmlDocument destinationDocument = new XmlDocument();
            destinationDocument.Load(Constants.DESTINATION_XML_FILENAME);

            if (createDefaultData)
            {
                List<Bus.sBus> buses = new List<Bus.sBus>();

                foreach (XmlNode depNode in sourceDocument.GetElementsByTagName(Constants.CITY_XML_NODE_NAME))
                {
                    foreach (XmlNode node in destinationDocument.GetElementsByTagName(Constants.CITY_XML_NODE_NAME))
                    {
                        //This is done to prevent source and destination being same
                        if (depNode.Attributes[Constants.CITY_XML_ATT_NAME].Value != node.Attributes[Constants.CITY_XML_ATT_NAME].Value)
                        {
                            buses.Add(new Bus.sBus(depNode.Attributes[Constants.CITY_XML_ATT_NAME].Value, node.Attributes[Constants.CITY_XML_ATT_NAME].Value, Utils.GetRandomSerialNumber(), 55));
                        }
                    }
                }

                if (buses.Count > 0)
                {
                    using (XmlWriter writer = XmlWriter.Create(Constants.BUS_XML_FILENAME))
                    {
                        writer.WriteStartDocument();
                        writer.WriteWhitespace("\n");
                        writer.WriteStartElement(Constants.BUS_ROOT_NAME);
                        writer.WriteWhitespace("\n");

                        foreach (Bus.sBus bus in buses)
                        {
                            writer.WriteStartElement(Constants.BUS_XML_NODE_NAME);

                            writer.WriteAttributeString(Constants.BUS_XML_NODE_ATT_DEPARTURE, bus.m_Source);
                            writer.WriteAttributeString(Constants.BUS_XML_NODE_ATT_DESTINATION, bus.m_Destination);
                            writer.WriteAttributeString(Constants.BUS_XML_NODE_ATT_BUS_NUMBER, bus.m_BusNumber.ToString());
                            writer.WriteAttributeString(Constants.BUS_XML_NODE_ATT_SEATS, bus.m_Seats.ToString());

                            writer.WriteEndElement();
                            writer.WriteWhitespace("\n");
                        }
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Close();
                    }
                }
            }
        }

        public static void Init()
        {
            InitBuses();
        }

        private static void CreateDefaultData(string fileName, string rootName, string nodeName, string attribName, string[] cityNames)
        {
            using (XmlWriter writer = XmlWriter.Create(fileName))
            {
                writer.WriteStartDocument();
                writer.WriteWhitespace("\n");
                writer.WriteStartElement(rootName);
                writer.WriteWhitespace("\n");

                foreach (string cityName in cityNames)
                {
                    writer.WriteStartElement(nodeName);

                    writer.WriteAttributeString(attribName, cityName);

                    writer.WriteEndElement();
                    writer.WriteWhitespace("\n");
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
        }
    }
}