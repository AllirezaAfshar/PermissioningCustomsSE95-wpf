using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomPermitWPF.Model;

namespace CustomPermitWPF.Domain
{
    public class Permission : IdentifiedEntity
    {
        public string Name { get; set; }

        public int MinistryID { get; set; }

        public Decleration Document { get; set; }
        public int DocumentID { get; set; }
        public Ministry Ministry { get; set; }

        public bool Passed;
    }
}