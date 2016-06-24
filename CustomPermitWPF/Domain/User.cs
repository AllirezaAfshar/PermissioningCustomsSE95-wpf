using System;
using System.Collections.Generic;
using CustomPermitWPF.Model;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomPermitWPF.Domain
{
    [Table("Users")]
    public class User : IdentifiedEntity
    {
        public User()
        {

        }
        public User(string username, string password, string Role)
        {
            this.Username = username;
            this.Password = password;
            this.Role = Role;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Decleration> Declerations { get; set; } 

    }
}