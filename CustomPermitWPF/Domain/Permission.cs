using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomPermitWPF.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomPermitWPF.Domain
{
    [Table("Permissions")]
    public class Permission : IdentifiedEntity
    {
        public string Name { get; set; }

        public int MinistryID { get; set; }

        public Ministry Ministry { get; set; }

        public virtual ICollection<Permission_Rule> PermissionRules { get; set; } 

        public Permission()
        {

        }
    }
}