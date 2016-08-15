using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.IO;
using System.Xml.Linq;
using TravelManager.Utilities;

namespace TravelManager.Model
{
    class DocumentLoader
    {
        public static XmlDocument GetBusDocument()
        {
            XmlDocument document = new XmlDocument();
            document.Load(Constants.BUS_XML_FILENAME);
            return document;
        }

        public static XmlDocument GetDepartureDocument()
        {
            XmlDocument document = new XmlDocument();
            document.Load(Constants.DEPARTURE_XML_FILENAME);
            return document;
        }

        public static XmlDocument GetDestinationDocument()
        {
            XmlDocument document = new XmlDocument();
            document.Load(Constants.DESTINATION_XML_FILENAME);
            return document;
        }
    }
}
