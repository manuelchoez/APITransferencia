using Microsoft.Extensions.Configuration;
using Serilog.Sinks.MSSqlServer;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transferencia.Infraestructura.Logging;
using Transferencia.Aplicacion.Constantes;

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
            
            string? baseDatos = _configuration.GetSection(ConstantesTransferenciaApi.BaseDatos).Value;
            string? nombreTabla = _configuration.GetSection(ConstantesTransferenciaApi.Tabla).Value;
            int batch = int.Parse(_configuration.GetSection(ConstantesTransferenciaApi.BatchPostingLimit).Value);
            TimeSpan batchTiempo = TimeSpan.Parse(_configuration.GetSection(ConstantesTransferenciaApi.BatchPeriod).Value);
            LogOpcion logOpcion = new LogOpcion();
            logOpcion.Cadena = cadena;
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
           .Enrich.WithProperty(ConstantesTransferenciaApi.Aplicacion, nombreAplicacion)
           .WriteTo.MSSqlServer(sinkOptions.Cadena, sinkOptions: sinkOptions.SqlOption);
        }
    }
}
