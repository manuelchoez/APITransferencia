using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Transferencia.Aplicacion.Util
{
    public class Response<TResponse>
    {
        public HttpStatusCode Status { get; }
        public bool EsError { get; }
        public TResponse Result { get; set; }
        public string Descripcion { get; set; }
        public object Mensaje { get; set; }        

        public Response(TResponse response, object mensaje)
        {
            Result = response;
            EsError = false;
            Mensaje = mensaje;
            Status = HttpStatusCode.OK;
        }

        protected Response(TResponse response, string descripcion)
        {
            Result = response;
            EsError = false;
            Descripcion = descripcion;          
            Status = HttpStatusCode.OK;
        }
        protected Response(Exception errors)
        {
            Mensaje = errors.Message;
            EsError = true;
            Status = HttpStatusCode.InternalServerError;
        }

        protected Response(Exception errors, string descripcion)
        {
            Mensaje = errors.Message;
            Descripcion = descripcion;            
            EsError = true;
            Status = HttpStatusCode.InternalServerError;
        }

        protected Response(object mensajeControlado)
        {
            Mensaje = mensajeControlado;
            EsError = false;
            Status = HttpStatusCode.OK;
        }

        protected Response(object mensajeControlado, string descripcion, string idSesion, string secuencial)
        {
            Mensaje = mensajeControlado;
            Descripcion = descripcion;            
            EsError = false;
            Status = HttpStatusCode.OK;
        }
        public static Response<TResponse> Error(Exception error)
        {
            return new Response<TResponse>(error);
        }

        public static Response<TResponse> Error(Exception error, string descripcion)
        {
            return new Response<TResponse>(error, descripcion);
        }

        public static Response<TResponse> Ok(TResponse response, object mensaje)
        {
            return new Response<TResponse>(response, mensaje);
        }

        public static Response<TResponse> Ok(TResponse response, string descripcion)
        {
            return new Response<TResponse>(response, descripcion);
        }        
    }
}
