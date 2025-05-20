using Microsoft.Extensions.Configuration;
using Serilog.Sinks.MSSqlServer;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transferencia.Infraestructura.Logging;

namespace Transferencia.Infraestructura.SeriLog
{
    public class SerilogHelper
    {
        private readonly IConfiguration _configuration;

        public SerilogHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public LogOpcion ConfigurarOpciones(string cadena)
        {
            string cadenaConexion = _configuration.GetConnectionString(cadena);
            string baseDatos = _configuration.GetSection(ConstantesRestMicroServicioParqueo.BaseDatos).Value;
            string nombreTabla = _configuration.GetSection(ConstantesRestMicroServicioParqueo.Tabla).Value;
            int batch = int.Parse(_configuration.GetSection(ConstantesRestMicroServicioParqueo.BatchPostingLimit).Value);
            TimeSpan batchTiempo = TimeSpan.Parse(_configuration.GetSection(ConstantesRestMicroServicioParqueo.BatchPeriod).Value);
            LogOpcion logOpcion = new LogOpcion();
            logOpcion.Cadena = cadenaConexion;
            logOpcion.BDatos = baseDatos;
            logOpcion.SqlOption = new MSSqlServerSinkOptions();
            logOpcion.SqlOption.TableName = nombreTabla;
            logOpcion.SqlOption.AutoCreateSqlTable = true;
            logOpcion.SqlOption.BatchPostingLimit = batch;
            logOpcion.SqlOption.BatchPeriod = batchTiempo;
            return logOpcion;

        }

        public LoggerConfiguration SerilogConfiguracion(string nombreAplicacion, string cadena)
        {
            LogOpcion sinkOptions = ConfigurarOpciones(cadena);
            return new LoggerConfiguration().MinimumLevel.Warning()
           .Enrich.FromLogContext()
           .Enrich.WithCorrelationId()
           .Enrich.WithClientIp()
           .Enrich.WithClientAgent()
           .Enrich.WithProperty(ConstantesRestMicroServicioParqueo.Aplicacion, nombreAplicacion)
           .WriteTo.MSSqlServer(sinkOptions.Cadena, sinkOptions: sinkOptions.SqlOption);
        }
    }
}
