using System;
using System.Collections.Generic;
using System.Text;

namespace TransportManagementSystem.Model
{
    public class Token
    {
        public int Id { get; set; }
        public Guid TokenId { get; set; }
        public int UserId { get; set; }
        public TokenTypes TokenType { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ExpiredAt { get; set; }

    }

    public enum TokenTypes
    {
        general = 1,
        week = 2
    }
}
