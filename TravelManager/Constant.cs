using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelManager
{
    class Constant
    {
        public const string XML_SERVER_PATH = "http://127.0.0.1/TravelManager/";

        public const string XML_FILE_NAME_SOURCE = "sourcePt.xml";
        public const string XML_FILE_NAME_DESTINATION = "destinationPt.xml";
        public const string XML_FILE_NAME_BUSDETAILS = "bookDt.xml";

        public const string XML_ROOT_ELEMENT_SOURCE = "source";
        public const string XML_ELEMENT_NODE_SOURCE = "sourcePt";

        public const string XML_ROOT_ELEMENT_DESTINATION = "destination";
        public const string XML_ELEMENT_NODE_DESTINATION = "destinationPt";

        public const string XML_ROOT_ELEMENT_BUSDETAILS = "busDetail";
        public const string XML_ELEMENT_NODE_BUSDETAILS = "busDetails";
    }
}
