using System;
using System.Collections.Generic;
using System.Text;

namespace TransportManagementSystem.Model
{
    public class TransportManager : User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserTypes UserType { get; set; }
    }
}
