using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppSignature.Dominio;
using Microsoft.EntityFrameworkCore;

namespace AppSignature.Infraestructura.Datos.Configs
{
    public class RolConfig : IEntityTypeConfiguration<Rol>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("tbRoles");
            builder.HasKey(c=>c.rolId);
        }
    }
}
