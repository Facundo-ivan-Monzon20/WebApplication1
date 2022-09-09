using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using userApp.DAL.Entities;

namespace userApp.DAL
{
    public class UserAppContex : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server:localhost:3306;database:userapp;user=root;password=");
        }
        public DbSet<UserContext> users { get; set; }

        public DbSet<GroupContext> groups { get; set; }
    }
}
