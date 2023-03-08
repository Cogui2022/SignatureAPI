using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSignature.Dominio
{
    public class Contract
    {
        public Guid contractId { get; set; }
        public string? contractName { get; set; }
        public List<Rol>? signature { get; set; }
        public int valueSign { get; set; }

    }
}
