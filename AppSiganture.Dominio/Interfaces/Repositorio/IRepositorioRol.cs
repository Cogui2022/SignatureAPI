using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSignature.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioRol<TEntidad,TEntidadID>:IAgregar<TEntidad>,IListar<TEntidad,TEntidadID>,ITransaccion
    {
    }
}
