using AppSignature.Dominio;
using AppSignature.Dominio.Interfaces.Repositorio;
using AppSignature.Infraestructura.Datos.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSignature.Infraestructura.Datos.Repositorios
{
    public class RolRepositorio : IRepositorioRol<Rol, Guid>
    {
        private RolContexto _db;

        public RolRepositorio(RolContexto db)
        {
            _db = db;
        }

        public Rol Agregar(Rol entidad)
        {
           entidad.rolId=Guid.NewGuid();
            _db.Roles.Add(entidad);
            return entidad;
        }

        public void GuardarTodosLosCambios()
        {
            _db.SaveChanges();
        }

        public List<Rol> Listar()
        {
           return _db.Roles.ToList();
        }

        public Rol SeleccionarPorID(Guid entidadId)
        {
            var rolSeleccionado = _db.Roles.FirstOrDefault(x=>x.rolId==entidadId);
            return rolSeleccionado!;
        }
    }
}
