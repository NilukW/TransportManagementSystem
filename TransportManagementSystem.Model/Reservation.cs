using System;
using System.Collections.Generic;
using System.Text;

namespace TransportManagementSystem.Model
{
    public class Reservation
    {
        public int PassengerId { get; set; }
        public int BusRouteId { get; set; }
        public int NoOfSheet { get; set; }
        public DateTime CreateDate { get; set; }
        public string Time { get; set; }
    }
}
