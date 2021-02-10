using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context : db tabloları ile proje class larını bağlar

    //indirmiş olduğumuz EfCore u implement ettik
    public class NorthwindContext : DbContext
    {
        //projenin hangi veritabanı ile ilişkili olduğunu belirttiğimiz
        //metottur.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //CONNECTION STRING
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
        }

        //benim Product tablomu vt deki Products tablosu ile bağlan
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
