using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.IO;
using System.Xml.Linq;

namespace TravelManager.Controller
{
    class TravelController
    {
        struct Source
        {
            public string m_SourceName;
            public int m_RouteNumber;

            public Source(string sName, int routeNum1)
            {
                m_SourceName = sName;
                m_RouteNumber = routeNum1;
            }
        }
        struct Destination
        {
            public string n_DestinationName;
            public int n_RouteNumber;

            public Destination(string dName, int routeNum2)
            {
                n_DestinationName = dName;
                n_RouteNumber = routeNum2;
            }
        }
        struct BusDetails
        {
            public int o_RouteNumber;
            public int o_AvailableSeats;
            public int o_BusFare;

            public BusDetails(int routeNum, int seat, int fare)
            {
                o_RouteNumber = routeNum;
                o_AvailableSeats = seat;
                o_BusFare = fare;

            }
        }
        public static void Init()
        {
            LoadXML();
        }
        private static void LoadXML()
        {
            if (!File.Exists(Constant.XML_FILE_NAME_SOURCE))
            {
                CreateSourceXMLData();
            }

            if (!File.Exists(Constant.XML_FILE_NAME_DESTINATION))
            {
                CreateDestinationXMLData();
            }
            if (!File.Exists(Constant.XML_FILE_NAME_BUSDETAILS))
            {
                CreateBusDetailsXMLData();
            }
        }
        public static void CreateSourceXMLData()
        {
            Source[] sourcePt = new Source[10];
            sourcePt[0] = new Source("Chennai", 0001);
            sourcePt[1] = new Source("Chennai", 0011);
            sourcePt[2] = new Source("Chennai", 0021);
            sourcePt[3] = new Source("Salem", 0002);
            sourcePt[4] = new Source("Salem", 0012);
            sourcePt[5] = new Source("Salem", 0022);
            sourcePt[6] = new Source("Coimbatore", 0003);
            sourcePt[7] = new Source("Coimbatore", 0013);
            sourcePt[8] = new Source("Coimbatore", 0023);
            

            using (XmlWriter writer = XmlWriter.Create(Constant.XML_FILE_NAME_SOURCE))
            {
                writer.WriteStartDocument();
                writer.WriteWhitespace("\n");
                writer.WriteStartElement(Constant.XML_ROOT_ELEMENT_SOURCE);
                writer.WriteWhitespace("\n");

                foreach (Source source in sourcePt)
                {
                    writer.WriteStartElement(Constant.XML_ELEMENT_NODE_SOURCE);

                    writer.WriteAttributeString("Source_Point_Name", source.m_SourceName);
                    writer.WriteAttributeString("Route_Number", source.m_RouteNumber.ToString());
                    
                    writer.WriteEndElement();
                    writer.WriteWhitespace("\n");
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
        }
        public static void CreateDestinationXMLData()
        {
            Destination[] destinationPt = new Destination[10];
            destinationPt[0] = new Destination("Pondicherry", 0001);
            destinationPt[1] = new Destination("Pondicherry", 0002);
            destinationPt[2] = new Destination("Pondicherry", 0003);
            destinationPt[3] = new Destination("Ooty", 0011);
            destinationPt[4] = new Destination("Ooty", 0012);
            destinationPt[5] = new Destination("Ooty", 0013);
            destinationPt[6] = new Destination("Yercaud", 0021);
            destinationPt[7] = new Destination("Yercaud", 0022);
            destinationPt[8] = new Destination("Yercaud", 0023);


            using (XmlWriter writer = XmlWriter.Create(Constant.XML_FILE_NAME_DESTINATION))
            {
                writer.WriteStartDocument();
                writer.WriteWhitespace("\n");
                writer.WriteStartElement(Constant.XML_ROOT_ELEMENT_DESTINATION);
                writer.WriteWhitespace("\n");

                foreach (Destination destination in destinationPt)
                {
                    writer.WriteStartElement(Constant.XML_ELEMENT_NODE_DESTINATION);

                    writer.WriteAttributeString("Destination_Point_Name", destination.n_DestinationName);
                    writer.WriteAttributeString("Route_Number", destination.n_RouteNumber.ToString());

                    writer.WriteEndElement();
                    writer.WriteWhitespace("\n");
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
        }
        public static void CreateBusDetailsXMLData()
        {
            BusDetails[] busDetails = new BusDetails[10];
            busDetails[0] = new BusDetails(0001,50,100);
            busDetails[1] = new BusDetails(0002,51,110);
            busDetails[2] = new BusDetails(0003,52,120);
            busDetails[3] = new BusDetails(0011,53,130);
            busDetails[4] = new BusDetails(0012,54,140);
            busDetails[5] = new BusDetails(0013,55,150);
            busDetails[6] = new BusDetails(0021,56,160);
            busDetails[7] = new BusDetails(0022,57,170);
            busDetails[8] = new BusDetails(0023,58,180);


            using (XmlWriter writer = XmlWriter.Create(Constant.XML_FILE_NAME_BUSDETAILS))
            {
                writer.WriteStartDocument();
                writer.WriteWhitespace("\n");
                writer.WriteStartElement(Constant.XML_ROOT_ELEMENT_BUSDETAILS);
                writer.WriteWhitespace("\n");

                foreach (BusDetails busDetail in busDetails)
                {
                    writer.WriteStartElement(Constant.XML_ELEMENT_NODE_BUSDETAILS);

                    writer.WriteAttributeString("Bus_Route_Number", busDetail.o_RouteNumber.ToString());
                    writer.WriteAttributeString("Number_of_Available_Seats", busDetail.o_AvailableSeats.ToString());
                    writer.WriteAttributeString("Bus_Fare", busDetail.o_BusFare.ToString());

                    writer.WriteEndElement();
                    writer.WriteWhitespace("\n");
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
        }
        private static XmlDocument m_document = null;
        public static XmlDocument LoadDocument(string documentName = Constant.XML_FILE_NAME_SOURCE)
        {
            if (m_document == null || !documentName.Contains(m_document.DocumentElement.Name))
            {
                m_document = new XmlDocument();
                m_document.Load(documentName);

            }
            return m_document;
        }
        public static XmlNodeList GetXMLNodeList(string XmlTagName = Constant.XML_ELEMENT_NODE_SOURCE)
        {
            return m_document.GetElementsByTagName(XmlTagName);
        }
    }
}
