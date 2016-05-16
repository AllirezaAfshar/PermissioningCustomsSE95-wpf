using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomPermitWPF.Domain
{
    public class Permission
    {
        public int ID { get; set; }
        public string name { get; set; }
        public Ministry Ministry { get; set; }

        public bool passed;
    }
}