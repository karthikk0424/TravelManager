using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelManager.Data
{
    class Passenger
    {
        public struct sPassenger
        {
            public string m_FullName;
            public string m_PhoneNumber;
            public string m_Address;

            public sPassenger(string name, string phone, string address)
            {
                m_FullName = name;
                m_PhoneNumber = phone;
                m_Address = address;
            }
        }
    }
}
