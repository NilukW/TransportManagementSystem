using System;
using System.Collections.Generic;
using System.Text;

namespace TransportManagementSystem.Model
{
    public class Driver
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
        public string LicenseNo { get; set; }
        public string ContactNo { get; set; }
    }
}
