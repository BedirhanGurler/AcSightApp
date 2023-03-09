using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public class AcSightDbContext: DbContext
    {
        // In this class, we made our database connection.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //SQL Server DB connection.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=Personals; Trusted_Connection=true");
            
            // In Memory Cache DB Connection.
            //optionsBuilder.UseInMemoryDatabase(databaseName: "StudentDB");
        }

        public DbSet<Personal> Personals { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
