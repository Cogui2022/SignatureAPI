using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSignature.Dominio.Interfaces
{
    public interface IValidar<TEntidad>
    {
        TEntidad Validar(List<TEntidad> Entidade);
    }
}
