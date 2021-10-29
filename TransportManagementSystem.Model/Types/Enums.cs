using System;
using System.Collections.Generic;
using System.Text;

namespace TransportManagementSystem.Model.Types
{
    public class Enums
    {
        public enum UserTypes
        {
            Passenger = 1,
            Driver = 2,
            TransportManager = 3,
            Inspector = 4
        }
    }

    public enum TokenTypes
    {
        general = 1,
        week = 2
    }
}
