using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Constructor sin parámetros que pasa un mensaje por defecto a otro 
        /// constructor de la Clase
        /// </summary>
        public ArchivosException()
            : this("Error en leer o guardar el archivo")
        {
        }
        /// <summary>
        /// Constructor que recibe como parámetro un string mensaje y lo pasa al 
        /// constructor de la Clase base 
        /// </summary>
        /// <param name="e"></param> Tipo string mensaje
        public ArchivosException(string mensaje)
            : base(mensaje)
        {
        }
        /// <summary>
        /// Constructor que pasa por parametros al constuctor de la base
        /// un mensaje y una innerException
        /// </summary>
        /// <param name="mensaje"></param> string mensaje para la excepcion
        /// <param name="innerException"></param> innerException
        public ArchivosException(string mensaje, Exception innerException)
            : base(mensaje, innerException)
        {
        }
    }
}
