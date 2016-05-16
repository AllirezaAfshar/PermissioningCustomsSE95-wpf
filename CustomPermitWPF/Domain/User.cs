using System;
using System.Collections.Generic;
using CustomPermitWPF.Model;

namespace CustomPermitWPF.Domain
{
    public class User : AbstractEntity
    {
        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Document> Documents { get; set; } 
    }
}