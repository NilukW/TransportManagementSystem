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
        public TokenPayments TokenPayment { get; set; }
    }

    public class TokenPayments {
        public int Id { get; set; }
        public int TokenId { get; set; }
        public string CardNumber { get; set; }
        public string NameOnCard { get; set; }
        public string Amount { get; set; }
        public string Cvv { get; set; }
        public string ExpiryDate { get; set; }
    }

    public enum TokenTypes
    {
        general = 1,
        week = 2
    }
}
