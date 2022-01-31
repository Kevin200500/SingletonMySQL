using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesarrolloMySQLPatronesDiseñoNetCore.Models;
using DesarrolloMySQLPatronesDiseñoNetCore.Utils;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace DesarrolloMySQLPatronesDiseñoNetCore.Persistence
{
    public class MySQLDBContext : DbContext
    {
        public DbSet<Usuarios> UsuariosDB { get; set; }
        public DbSet<ARTICULOS> ArticulosDB { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Constantes.connectionString,new MySqlServerVersion(new System.Version(8, 0, 28)));
        }
    }
}
