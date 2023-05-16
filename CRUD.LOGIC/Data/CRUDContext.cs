using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using DataModel = CRUD.LOGIC.DataModel;

namespace CRUD.LOGIC.Data
{
    public class CRUDContext : DbContext 
    {
        
        public CRUDContext(DbContextOptions<CRUDContext> options) : base(options)
        {
        }

        public DbSet<DataModel.Journal> Journals { get; set; }


    }
}
