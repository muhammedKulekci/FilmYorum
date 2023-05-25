using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; // sonradan ekledik framework
using EntityFrameworkExample.Models;

namespace EntityFrameworkExample.DataSource
{
    internal class DataContext:DbContext
    {
        public DataContext() : base("name=ConnectionDb") { }

        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }

    }
}
