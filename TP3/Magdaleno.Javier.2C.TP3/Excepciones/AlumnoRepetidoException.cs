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
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Constructor sin parametro que pasa por parámetro un mensaje por defecto a otro 
        /// constructor de la clase
        /// </summary>
        public AlumnoRepetidoException()
            :this("El Alumno esta repetido.")
        {
        }
        /// <summary>
        /// Constructor que recibe un paráetro mensaje y lo pasa la Clase Base para
        /// que lo inicialice los atributos
        /// </summary>
        /// <param name="mensaje"></param> Tipo string mensaje que contiene la excepción
        public AlumnoRepetidoException(string mensaje)
            :base(mensaje)
        {
        }
    }
}
