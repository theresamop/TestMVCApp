using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
namespace TestMVC.Models
{
   
    public class TestEntities : DbContext
    {
        public int ClickCount { get; set; }

        public DbSet<TestModel> TestModel { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestModel>().ToTable("ButtonClick");


            base.OnModelCreating(modelBuilder);
        }
    }
}