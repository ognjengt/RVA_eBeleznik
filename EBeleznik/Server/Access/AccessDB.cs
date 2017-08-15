using Common.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Access
{
    public class AccessDB : DbContext
    {
        public AccessDB() : base("dbConnection2015") { Database.SetInitializer(new MigrateDatabaseToLatestVersion<AccessDB, Configuration>()); }

        public DbSet<User> Users { get; set; }
        public DbSet<Beleska> Beleske { get; set; }
    }
}
