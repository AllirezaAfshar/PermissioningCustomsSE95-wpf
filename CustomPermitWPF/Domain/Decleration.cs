using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using CustomPermitWPF.Model;



namespace CustomPermitWPF.Domain
{
    public class ComodityType : IdentifiedEntity
    {
        public String value { get; set; }
    }

    public class Decleration : IdentifiedEntity
    {
        public int UserID { get; set; }
        public User user { get; set; }

        public virtual ICollection<Permission> PermissionList { get; set; }
        public string CommodityName { get; set; }

        public int Price { get; set; }

        public string CountryOrigin { get; set; }

        public DateTime RecordDateTime { get; set; }

        public int Amount { get; set; }

        public Decleration(User u, int ID, string commodityName)
        {
            user = u;
            PermissionList = new List<Permission>();
            this.ID = ID;
            this.CommodityName = commodityName;
        }

        public Decleration(User u, int ID, string commodityName, string countryOfOrigin, int amount, int price)
        {
            user = u;
            this.ID = ID;
            this.CommodityName = commodityName;
            this.CountryOrigin = countryOfOrigin;
            this.Amount = amount;
            this.Price = price;
        }
    }
}