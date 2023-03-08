using AppSignature.Aplicaciones.Common;
using AppSignature.Aplicaciones.Interface;
using AppSignature.Dominio;
using AppSignature.Dominio.Interfaces;
using AppSignature.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppSignature.Aplicaciones.Servicios
{
    public class GenerateWinSignatureServicio : ComonFunctions, IServicioGenerateWinSignature<Contract>
    {
        private readonly IRepositorioRol<Rol, Guid> _repositorioRol;
        public GenerateWinSignatureServicio(IRepositorioRol<Rol, Guid> repositorioRol)
        {
            _repositorioRol = repositorioRol;
        }

        public string GenerateWinSignature(List<Contract> contracts)
        {
            if (!ValidateContracstSignature(contracts)) throw new ArgumentNullException("Contratos requeridos para validacion");

            foreach (var contract in contracts)
            {
                GetValueRolsPoint(contract);
                CalculateValueSign(contract);
            }
          
            return CalculateSignature(contracts);
        }

        #region Private
        private string CalculateSignature(List<Contract> contracts)
        {
            //var rols = _repositorioRol.Listar(); con los roles en BD sacariamos lis que haya especificados para poder usarlos al calcular el valor
            var rols = CrearListaRols();
          
            var contract = contracts.FirstOrDefault(X =>(X.signature!.Exists(z=>z.name=="#")));

            var diferencias = contracts.Skip(1).Zip(contracts, (x, y) => x.valueSign - y.valueSign);

            return rols.OrderByDescending(x => x.points).LastOrDefault(x => x.points > diferencias.FirstOrDefault())!.name!;

        }

    

        private bool ValidateContracstSignature(List<Contract> contracts)
        {
            var notSigns = 0;
            foreach (var contract in contracts)
            {
                if (contract.signature!.Exists(x => x.name == "#"))
                {
                    notSigns = notSigns + 1;
                }
                
            }
            return notSigns >1?false:true;
        }

        #endregion
    }
}
