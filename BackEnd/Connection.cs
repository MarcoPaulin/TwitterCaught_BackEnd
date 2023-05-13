using MySqlConnector;
using System.Data.SqlClient;

using Microsoft.EntityFrameworkCore;
using BackEnd.Model;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace BackEnd
{
    public class ConnectionDB : DbContext
    {
        /*

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();
            optionsBuilder.UseMySql(configuration.GetConnectionString("MaConnexion"));
        }
    }
        public ConnectionDB(DbContextOptions<ConnectionDB> options) : base(options)
        {
        }

        public ConnectionDB() { }

        public DbSet<Users> users { get; set; }
        public DbSet<tweet> tweet { get; set; }
        public DbSet<followers> followers { get; set; } */


    }
    
}
