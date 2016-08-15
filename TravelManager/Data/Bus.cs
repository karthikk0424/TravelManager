using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelManager.Data
{
    class Bus
    {
        public struct sBus
        {
            public string m_Source;
            public string m_Destination;
            public int m_BusNumber;
            public int m_Seats;

            public sBus(string source, string destination, int busNumber, int seats)
            {
                m_Source = source;
                m_Destination = destination;
                m_BusNumber = busNumber;
                m_Seats = seats;
            }
        }
    }
}
