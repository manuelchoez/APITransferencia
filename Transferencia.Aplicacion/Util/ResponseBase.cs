using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transferencia.Aplicacion.Util
{
    public abstract class ResponseBase
    {
        public string? Codigo { get; set; }
        public bool EsError { get; set; }
        public object? Mensaje { get; set; }
    }
}
