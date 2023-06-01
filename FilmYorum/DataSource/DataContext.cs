using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FilmYorum.Models;

namespace FilmYorum.DataSource
{
    internal class DataContext : DbContext
    {
        public DataContext() : base ("name=ConnectionDb") { }

        public DbSet<User> User { get; set; }
        public DbSet<Films> Films { get; set; }
        public DbSet<Comments> Comments { get; set; }
    }
}
