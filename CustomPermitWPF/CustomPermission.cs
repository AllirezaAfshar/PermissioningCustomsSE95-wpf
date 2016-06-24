using System.Collections.Generic;
using CustomPermitWPF.Domain;
using CustomPermitWPF.Model;

namespace CustomPermitWPF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Permission_Rule : IdentifiedEntity
    {
        public  Permission Permission { get; set; }
        public Rule Rule { get; set; } 

        public int PermissionID { get; set; }
        public int RuleID { get; set; }
    }

    public partial class CustomPermission : DbContext
    {
        public static User active_user = null;
        public static Rules rules = new Rules();

        public CustomPermission()
            : base("name=CustomPermission")
        {
        }

        public virtual DbSet<CommodityType> CommodityTypes { get; set; }
        public virtual DbSet<Decleration> Declerations { get; set; }
        public virtual DbSet<Ministry> Ministries { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Permission_Rule> PermissionRules { get; set; }


        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e=>e.Declerations)
                .WithRequired(e=>e.User)
                .HasForeignKey(e=>e.UserID);

            modelBuilder.Entity<Ministry>()
                .HasMany(e=>e.Permissions)
                .WithRequired(e=>e.Ministry)
                .HasForeignKey(e=>e.MinistryID)
                .WillCascadeOnDelete(true);
            

            modelBuilder.Entity<CommodityType>()
                .HasMany(e=>e.Declerations)
                .WithRequired(e=>e.CommodityType)
                .HasForeignKey(e=>e.CommodityTypeId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Rule>()
                .HasMany(e=>e.PermissionRules)
                .WithRequired(e=>e.Rule)
                .HasForeignKey(e=>e.RuleID)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Permission>()
                .HasMany(e=>e.PermissionRules)
                .WithRequired(e=>e.Permission)
                .HasForeignKey(e=>e.PermissionID)
                .WillCascadeOnDelete(true);
        }
    }
}
