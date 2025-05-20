using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transferencia.Infraestructura.Logging
{

    public class LogOpcion
    {
        public string BDatos { get; set; }
        public string Cadena { get; set; }
        public MSSqlServerSinkOptions SqlOption { get; set; }
    }
}
