using System;
using System.Collections.Generic;
using System.Security.Principal;


namespace CustomPermitWPF.Domain
{
    public class Documents
    {
        public User user { get; set; }
        public List<Permission> PermissionList { get; set; }
        public int ID;
        public string CommodityName { get; set; }

        public int Price { get; set; }

        public string CountryOrigin { get; set; }

        public DateTime RecordDateTime { get; set; }

        public int Amount { get; set; }

        public Documents(User u, int ID, string commodityName)
        {
            user = u;
            PermissionList = new List<Permission>();
            this.ID = ID;
            this.CommodityName = commodityName;
        }

        public Documents(User u, int ID, string commodityName, string countryOfOrigin, int amount, int price)
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