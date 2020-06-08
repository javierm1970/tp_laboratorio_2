using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    /// <summary>
    /// Interfaz Generica 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IArchivos<T>
    {
        /// <summary>
        /// Firma de Método Guardar()
        /// </summary>
        bool Guardar(string archivo, T datos);
        /// <summary>
        /// Firma de Método Leer() 
        /// </summary>
        bool Leer(string archivo, out T datos);
    }

}
