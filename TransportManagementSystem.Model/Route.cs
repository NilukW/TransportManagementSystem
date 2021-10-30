using System;
using System.Collections.Generic;
using System.Text;

namespace TransportManagementSystem.Model
{
    public class Route
    {
        public int RouteId { get; set; }
        public string RouteNo { get; set; }
        public string RouteName { get; set; }
        public List<BusStops> ListOfRoutes { get; set; }
    }

    public class BusStops {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public int Amount { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
