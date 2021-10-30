using System;
using System.Collections.Generic;
using System.Text;

namespace TransportManagementSystem.Model
{
    public class Ticket
    {
        public int Id { get; set; }
        public int BusId { get; set; }
        public int TokenId { get; set; }
        public int BusStopId { get; set; }
        public DateTime? CheckedTime { get; set; }
    }
}
