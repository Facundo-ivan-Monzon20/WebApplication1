using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
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
            optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=userapp;User Id=root;Password=root");
        }
        public DbSet<UserContext> users { get; set; }

        public DbSet<GroupContext> groups { get; set; }
    }
}
