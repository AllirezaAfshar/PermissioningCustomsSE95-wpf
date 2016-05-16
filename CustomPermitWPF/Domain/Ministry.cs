using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CustomPermitWPF.Model;

namespace CustomPermitWPF.Domain
{
    [Table("Ministry")]
    public class Ministry : AbstractEntity
    {
        public string name { get; set; }
    }
}