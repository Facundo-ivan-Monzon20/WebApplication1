using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace userApp.DAL
{
    public class UserAppContex : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server:localhost:3000;database:userapp;user=root;password=");
        }

        public DbSet<Entities.userContext> users { get; set; };
    }
}
