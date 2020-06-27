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
    public static class GuardaString
    {
        /// <summary>
        /// que Escribe y agrega datos en formato Texto.
        /// Caso contrario, lanzará la excepción: ArchivosException().
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
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
