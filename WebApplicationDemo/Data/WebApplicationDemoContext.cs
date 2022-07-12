using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Data
{
    public class WebApplicationDemoContext : DbContext
    {
        public WebApplicationDemoContext (DbContextOptions<WebApplicationDemoContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplicationDemo.Models.Book>? Book { get; set; }
    }
}
