using System;
using System.Collections.Generic;
using System.Text;

namespace TransportManagementSystem.Model
{
    public class Driver : User
    {
        public string Fullname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string LicenseNo { get; set; }
        public string ContactNo { get; set; }
    }
}
