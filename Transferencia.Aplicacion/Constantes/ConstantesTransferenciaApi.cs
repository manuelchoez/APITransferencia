using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transferencia.Dominio.Entidades;

namespace Transferencia.Aplicacion.Constantes
{
    public class ConstantesTransferenciaApi
    {
        public const string Tabla = "Log:tabla";
        public const string AutoCreateSqlTable = "Log:autoCreateSqlTable";
        public const string BatchPostingLimit = "Log:batchPostingLimit";
        public const string BatchPeriod = "Log:batchPeriod";
        public const string BaseDatos = "Log:baseDatos";
        public const string Aplicacion = "Aplicacion";
        public const string CadenaConexion = "DefaultConnection";

        public const string MsjListaBilleteras = "Lista de Billeteras obtenida correctamente";
        public const string MsjBilletera = "Lista de Billeteras obtenida correctamente";

        public const string MsjBilleteraActualizada = "Se actualizo la billetera correctamente";
        public const string MsjBilleteraCreada = "Se creo la billetera correctamente";
        public const string MsjBilleteraDuplicada = "documentoid ya cuenta con una billetera";
        public const string MsjBilleteraEliminada = "Se elimino la billetera correctamente";

        public const string MsjBilleteraNoEncontrada = "No se encontro la billetera";

        public const string MsjValiacionDatos = "Ingresar todos los datos de la billetera";
        public const string MsjValiacionValorBalance = "Valor de balance incorrectos";
        public const string MsjValiacionNombre = "nombre es obligatorio";
        public const string MsjValiacionDocumentId = "documentid es obligatorio";

        public const string MsjValiacionMontoIncorrecto = "Monto Incorrecto";
        public const string MsjMovimientoCreado = "Transaccion reralizada correctamente";
        public const string MsjBilleteraSinFondos = "Sin fondos";
        public const string MsjValiacionType = "Tipo de movimiento incorrecto";
    }
}
