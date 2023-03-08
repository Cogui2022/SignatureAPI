using AppSignature.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSignature.Aplicaciones.Common
{
    public abstract class ComonFunctions
    {
        public void GetValueRolsPoint(Contract contract)
        {
            var valueSign = 0;
            //var rols = _repositorioRol.Listar(); con los roles en BD sacariamos lis que haya especificados para poder usarlos al calcular el valor
            var rols = CrearListaRols();

            foreach (var sign in contract.signature!)
            {
                if(sign.name!="#")
                sign.points = valueSign + rols.FirstOrDefault(x=>x.name==sign.name)!.points;
            }
            if (contract.signature.Exists(x => x.name == "K"))
            {
                contract.signature.FirstOrDefault(X => X.name == "V")!.points = 0;
            }
        }

        public void CalculateValueSign(Contract contract)
        {
            var valueSign = 0;
            foreach (var sign in contract.signature!)
            {
                valueSign = valueSign + sign.points;
            }
            contract.valueSign = valueSign;

        }
        public List<Rol> CrearListaRols()
        {
            var lista = new List<Rol>();
            lista.Add(new Rol { name="K", points=5,rolId=new Guid()});
            lista.Add(new Rol { name = "N", points = 2, rolId = new Guid() });
            lista.Add(new Rol { name = "V", points = 1, rolId = new Guid() });
            return lista;

        }
    }
}
