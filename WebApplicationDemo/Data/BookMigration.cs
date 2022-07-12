using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Data
{
    public class BookMigration : System.Data.Entity.DbContext
    {
        public BookMigration() : base("BookDB")
        {
        }

        //public System.Data.Entity.DbSet<Book> Books { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{

        //}
    }
}
