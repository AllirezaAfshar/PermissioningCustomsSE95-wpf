using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CustomPermitWPF.Model;

namespace CustomPermitWPF.Domain
{
    [Table("Ministries")]
    public class Ministry : IdentifiedEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; } 

        public Ministry()
        {
        }
    }
}