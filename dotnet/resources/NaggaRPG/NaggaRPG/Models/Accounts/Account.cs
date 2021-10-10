using NaggaRPG.Models.Common;
using System;

namespace NaggaRPG.Models.Accounts
{
    public class Account : IDbEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastActiveDate { get; set; }
        public bool IsLogged { get; set; }
    }
}