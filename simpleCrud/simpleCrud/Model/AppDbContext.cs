using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleCrud.Model
{
    internal class AppDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\gowds\source\repos\simpleCrud\simpleCrud\Teachers\teachers.db");
        }

        public DbSet<Teacher> Teachers { get; set; }

    }
}
