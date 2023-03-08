using AppSignature.Dominio;
using AppSignature.Infraestructura.Datos.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSignature.Infraestructura.Datos.Contextos
{
    public class RolContexto : DbContext
    {
        public DbSet<Rol> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
          
          //  optionsBuilder.UseSqlServer("Server=tcp:serverappsign.database.windows.net,1433;Initial Catalog=app-signature;Persist Security Info=False;User ID=adminappsign;Password=Channel321*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

           // optionsBuilder.UseSqlServer("Server=DESKTOP-UANGAEK\\SQLEXPRESS;Initial Catalog=app-signature;Persist Security Info=False;User ID=Cogui;Password=Valencia2008;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            // optionsBuilder.UseInMemoryDatabase("TestDb");
            optionsBuilder.UseSqlServer(@"Server=(localdb)\DESKTOP-UANGAEK\\SQLEXPRESS;Database=Clientes");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RolConfig());
        }
    }
}
