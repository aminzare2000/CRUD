using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISC_Sample.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ISC_Sample.EntityFrameworkCore.ISCDbContextProject
{
    public class IscDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        //protected IscDbContext(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        public IscDbContext(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ISCConnectionString"));
            optionsBuilder.UseInMemoryDatabase(databaseName:"ISCDb");
            //base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Journal> Journals { get; set; }
        public DbSet<Organization> Organizations { get; set; }
    }
}