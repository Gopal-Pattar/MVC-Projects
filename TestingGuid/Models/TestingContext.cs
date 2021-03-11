using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingGuid.Models
{
    public class TestingContext : DbContext
    {
       
        public TestingContext(DbContextOptions<TestingContext> options) : base(options)
        { }
        public DbSet<Testing> Testings { get; set; }

    }
}

