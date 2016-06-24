using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using CustomPermitWPF.Model;



namespace CustomPermitWPF.Domain
{
    [Table("Commodity_Types")]
    public class CommodityType : IdentifiedEntity
    {
        public virtual ICollection<Decleration> Declerations { get; set; }
         

        public CommodityType()
        {
        }
        public String value { get; set; }
    }

    [Table("Declerations")]
    public class Decleration : IdentifiedEntity
    {
        public Decleration()
        {
        }

        public int UserID { get; set; }
        public User User { get; set; }

        public virtual ICollection<Permission> PermissionList { get; set; }

        public int CommodityTypeId { get; set; }
        public CommodityType CommodityType { get; set; }
        public string CommodityName { get; set; }

        public int Price { get; set; }

        public string CountryOrigin { get; set; }

        public DateTime RecordDateTime { get; set; }

        public int Amount { get; set; }

        public Decleration(User u, int ID, string commodityName)
        {
            UserID = u.ID;
            PermissionList = new List<Permission>();
            this.ID = ID;
            this.CommodityName = commodityName;
            RecordDateTime = DateTime.Now;

        }

        public Decleration(User u, int ID, string commodityName, string countryOfOrigin, int amount, int price)
        {
            UserID = u.ID;
            this.ID = ID;
            this.CommodityName = commodityName;
            this.CountryOrigin = countryOfOrigin;
            this.Amount = amount;
            this.Price = price;
            RecordDateTime = DateTime.Now;
            CommodityType = new CommodityType();
        }
    }
}