using Domain.Entities;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Data
{
    public class CGAContext : DbContext
    {
        public CGAContext():base("name=Alias")
        {
  

    }



        public DbSet<commentaire> commentaire { get; set; }
        public DbSet<vehicleswreck> vehicleswreck { get; set; }
        public DbSet<claim> claim { get; set; }
        public DbSet<report> report { get; set; }
        public DbSet<user> user { get; set; }
        public DbSet<policy> policy { get; set; }
        public DbSet<forum> form { get; set; }
        public DbSet<contract> contract { get; set; }
    }
}
