using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class TrackingIDRepetidoException : Exception
    {
        /// <summary>
        /// Constructor sin parámetros que pasa un mensaje por defecto a otro 
        /// constructor de la Clase
        /// </summary>
        public TrackingIDRepetidoException()
       : this("Error!. El Paquete figura ya cargado.")
        {
        }
        /// <summary>
        /// Constructor que recibe como parámetro un string mensaje y lo pasa al 
        /// constructor de la Clase base 
        /// </summary>
        /// <param name="e"></param> Tipo string mensaje
        public TrackingIDRepetidoException(string mensaje)
            : base(mensaje)
        {
        }
        /// <summary>
        /// Constructor que pasa por parametros a otro constuctor de la clase
        /// una innerException recibida tambien por parametros, juntamente con 
        /// un mensaje por defecto
        /// </summary>
        /// <param name="mensaje"></param> string mensaje para la excepcion
        /// <param name="innerException"></param> innerException
        public TrackingIDRepetidoException(Exception innerException)
            : this("Error!. El Paquete figura ya cargado.", innerException)
        {
        }
        /// <summary>
        /// Constructor que pasa por parametros al constuctor de la base
        /// un mensaje y una innerException
        /// </summary>
        /// <param name="mensaje"></param> string mensaje para la excepcion
        /// <param name="innerException"></param> innerException
        public TrackingIDRepetidoException(string mensaje, Exception innerException)
            : base(mensaje, innerException)
        {
        }
    }
}
