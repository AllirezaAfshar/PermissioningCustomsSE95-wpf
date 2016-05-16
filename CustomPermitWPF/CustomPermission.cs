using CustomPermitWPF.Domain;

namespace CustomPermitWPF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CustomPermission : DbContext
    {
        public CustomPermission()
            : base("name=CustomPermission")
        {
        }

        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Ministry> Ministries { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<User> Users { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e=>e.Documents)
                .WithRequired(e=>e.user)
                .HasForeignKey(e=>e.UserID)
                .WillCascadeOnDelete(true);


            modelBuilder.Entity<Ministry>()
                .HasMany(e=>e.Permissions)
                .WithRequired(e=>e.Ministry)
                .HasForeignKey(e=>e.MinistryID)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Document>()
                .HasMany(e=>e.PermissionList)
                .WithRequired(e=>e.Document)
                .HasForeignKey(e=>e.DocumentID)
                .WillCascadeOnDelete(true);
        }
    }
}
