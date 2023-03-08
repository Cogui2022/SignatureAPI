using AppSignature.Dominio;
using AppSignature.Dominio.Interfaces;
using AppSignature.Dominio.Interfaces.Repositorio;
using AppSignature.Aplicaciones.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppSignature.Aplicaciones.Common;

namespace AppSignature.Aplicaciones.Servicios
{
    public class ValidacionServicio : ComonFunctions, IServicioValidacion<Contract>
    {
        private readonly IRepositorioRol<Rol, Guid> _repositorioRol;
        public ValidacionServicio(IRepositorioRol<Rol,Guid> repositorioRol) 
        {
            _repositorioRol = repositorioRol;
        }
        public Contract Validar(List<Contract> contracts)
        {
            if (contracts == null) throw new ArgumentNullException("Contratos requeridos para validacion");

            foreach (var contract in contracts)
            {
                GetValueRolsPoint(contract);
                CalculateValueSign(contract);
            }
          
            return contracts.OrderByDescending(x=>x.valueSign).FirstOrDefault()!;
        }

      
    }
}
