using AppSignature.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSignature.Aplicaciones.Interface
{
    public interface IServicioValidacion<TEntidad>:IValidar<TEntidad>
    {
    }
}
