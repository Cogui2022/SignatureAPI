using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppSignature.Dominio;
using AppSignature.Aplicaciones.Interface;
using AppSignature.Dominio.Interfaces.Repositorio;

namespace AppSignature.Aplicaciones.Servicios
{
    public class RolServicio : IServicioBase<Rol, Guid>
    {
        private readonly IRepositorioRol<Rol,Guid> _repoRol;

        public RolServicio(IRepositorioRol<Rol, Guid> repoRol)
        {
            _repoRol = repoRol;
        }

        public Rol Agregar(Rol entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El 'Rol' es requerido");
            var resultRol=_repoRol.Agregar(entidad);
            _repoRol.GuardarTodosLosCambios();
            return resultRol;
        }

        public void Editar(Rol entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El 'Rol' es requerido pàra editar");
            //_repoRol.Editar(entidad);
            _repoRol.GuardarTodosLosCambios();

        }

        public void Eliminar(Guid entidadId)
        {
            //_repoRol.Eliminar(entidadId);
            _repoRol.GuardarTodosLosCambios();
        }

        public List<Rol> Listar()
        {
           return _repoRol.Listar();
        }

        public Rol SeleccionarPorID(Guid entidadId)
        {
            return _repoRol.SeleccionarPorID(entidadId);
        }
    }
}
