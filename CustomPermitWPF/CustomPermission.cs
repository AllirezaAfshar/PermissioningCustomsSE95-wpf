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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
