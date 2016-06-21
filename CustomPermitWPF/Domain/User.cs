using System;
using System.Collections.Generic;
using CustomPermitWPF.Model;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomPermitWPF.Domain
{
    [Table("Users")]
    public class User
    {
        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        [Key]
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Document> Documents { get; set; } 

    }
}