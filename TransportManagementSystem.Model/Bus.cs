using System;
using System.Collections.Generic;
using System.Text;

namespace TransportManagementSystem.Model
{
    public class Bus
    {
        public int Id { get; set; }
        public string BusCode { get; set; }
        public string NumberPlate { get; set; }
        public string CompanyName { get; set; }
        public string Manufacturer { get; set; }
        public int MnufacturerYear { get; set; }
        public int NumberOfSeats { get; set; }
        public string QrCode { get; set; }
    }
}
