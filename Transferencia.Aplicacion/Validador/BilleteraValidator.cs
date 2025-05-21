using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transferencia.Dominio.Entidades;

namespace Transferencia.Aplicacion.Validador
{
    public static class BilleteraValidator
    {
        public static (bool esValido, string mensaje) Validar(Billetera billetera)
        {
            if (billetera == null)
                return (false, Constantes.ConstantesTransferenciaApi.MsjValiacionDatos);

            if (billetera.Balance <= 0)
                return (false, Constantes.ConstantesTransferenciaApi.MsjValiacionValorBalance);

            if (string.IsNullOrEmpty(billetera.Name))
                return (false, Constantes.ConstantesTransferenciaApi.MsjValiacionNombre);

            if (string.IsNullOrEmpty(billetera.Documentid))
                return (false, Constantes.ConstantesTransferenciaApi.MsjValiacionDocumentId);

            return (true, string.Empty);
        }
    }
}
