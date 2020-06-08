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
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Constructor sin parametro que pasa por parámetro un mensaje por defecto a otro 
        /// constructor de la clase
        /// </summary>
        public NacionalidadInvalidaException()
            :this("Nacionalidad no coincide con el número de DNI")
        {
        }
        /// <summary>
        /// Constructor que pasa a la base el parametro que recibe para que 
        /// inicialice el atributo message
        /// </summary>
        /// <param name="mensaje"></param> Tipo string mensaje
        public NacionalidadInvalidaException(string mensaje)
            :base(mensaje)
        {
        }
    }
}
