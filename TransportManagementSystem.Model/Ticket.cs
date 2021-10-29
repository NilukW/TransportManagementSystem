using System;
using System.Collections.Generic;
using System.Text;

namespace TransportManagementSystem.Model
{
    public class Ticket
    {
        public int Id { get; set; }
        public int BusId { get; set; }
        public string TokenId { get; set; }
        public string BusStopId { get; set; }
        public DateTime CheckedTime { get; set; }
    }
}
