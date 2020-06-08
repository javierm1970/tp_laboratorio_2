using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Clase derivada de la clase Exception 
    /// </summary>
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Constructor sin parámetros que pasa un mensaje por defecto a otro 
        /// constructor de la Clase
        /// </summary>
        public DniInvalidoException()
            :this("DNI Inválido")
        {
        }
        /// <summary>
        /// Constructor que recibe como parámetro un Tipo Exception y lo pasa a otro 
        /// constructor de la Clase conjuntamente con un mensaje por defecto 
        /// </summary>
        /// <param name="e"></param> Tipo Exception innerException
        public DniInvalidoException(Exception e)
            :this("DNI Invalido",e)
        {
        }
        /// <summary>
        /// Constructor que pasa a la base el parametro que recibe para que 
        /// inicialice el atributo message
        /// </summary>
        /// <param name="mensaje"></param> Tipo string mensaje
        public DniInvalidoException(string mensaje)
            :base(mensaje)
        {
        }
        /// <summary>
        /// Constructor que pasa a la base los parametros que recibe para que 
        /// inicialice el atributo message
        /// </summary>
        /// <param name="mensaje"></param> Tipo string mensaje
        /// <param name="e"></param> Tipo Exception innerException
        public DniInvalidoException(string mensaje, Exception e)
            :base(mensaje,e)
        {
        }
    }
}
