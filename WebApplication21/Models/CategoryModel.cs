namespace WebApplication21.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CategoryModel : DbContext
    {
        public CategoryModel()
            : base("name=CategoryModel")
        {
        }

        public virtual DbSet<CATEGORIES> CATEGORIES { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<WebApplication21.Models.BOOKS> BOOKS { get; set; }
    }
}
