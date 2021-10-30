using System;
using System.Collections.Generic;
using System.Text;

namespace TransportManagementSystem.Model
{
    public class Inspector : User
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
    }
}
