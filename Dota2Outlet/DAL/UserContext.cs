using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//imports
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Dota2Outlet.Models;

namespace Dota2Outlet.DAL
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}