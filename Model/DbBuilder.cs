using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace halloween.Model
{
    public class DbBuilder : DbContext
    {
        // DB-RELATED: ADD THESE CONSTRUCTORS!
        public DbBuilder() {}
        public DbBuilder(DbContextOptions<DbBuilder> options) : base(options) { }

        //DB-RELATED: CREATE A DB FOREACH EXISTING MODEL(S0
        //public DbSet<greetings> Friends { get; set; }
        //public DbSet<greetings> Frenemies { get; set; }
        //public DbSet<greetings> Enemies { get; set; }
        public DbSet<greetings> greetings { get; set; }
    }
}
