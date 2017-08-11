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
        public AccessDB() : base("dbConnection2015") { }

        public DbSet<User> Users { get; set; }
    }
}
