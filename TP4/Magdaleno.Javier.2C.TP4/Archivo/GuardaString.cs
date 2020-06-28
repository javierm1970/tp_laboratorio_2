using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Extensiones
{
    // Clase estatica extension de otras clases
    public static class GuardaString
    {
        /// <summary>
        /// Escribe y/o agrega datos en formato Texto a un archivo pasado por parámetro.
        /// Caso contrario, lanzará la excepción: ArchivosException().
        /// </summary>
        /// <param name="archivo"></param> ruta donde estará el archivo a escribir
        /// <param name="datos"></param> datos que se escribirán en el archivo
        /// <returns> true si se pudo escribir en el archivo, false caso contrario </returns>
        public static bool Guardar(this string texto,string archivo)
        {
            bool flagGuardar = false;

            try
            {
                if (!(archivo is null))
                {
                    using (StreamWriter sw = new StreamWriter(archivo, true))
                    {
                        sw.WriteLine(texto);
                        flagGuardar = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException("No se pudo guardar el archivo de Texto", ex);
            }
            return flagGuardar;
        }
    }
}
