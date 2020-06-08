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
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Constructor que recibe un paráetro del Tipo Exception
        /// y lo pasa la Clase Base conjuntamente con un mensaje por defecto 
        /// para que lo inicialice los atributos message e innerException
        /// </summary>
        /// <param name="mensaje"></param> Tipo string mensaje que contiene la excepción
        public ArchivosException(Exception innerException)
            :base("Error en Archivo",innerException)
        {
        }
    }
}
