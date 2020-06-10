using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    /// <summary>
    /// Clase Texto que implementa la Interfaz IArchivos<string>
    /// </summary>
    public class Texto : IArchivos<string> 
    {
        /// <summary>
        /// Método que escribe un archivo .txt
        /// </summary>
        /// <param name="archivo"></param> Tipo string ruta del archivo a guardar
        /// <param name="datos"></param> Tipo string datos que se van a escribir en el archivo
        /// <returns> bool retornará true si se escribio el archivo 
        /// de lo contrario retornará false </returns>
        public bool Guardar(string archivo, string datos)
        {
            if (datos is string)
            {
                // Abro el archivo ubicado en una dirección de la máquina
                StreamWriter sw = new StreamWriter(archivo);

                // Agrego un texto
                sw.WriteLine(datos);

                // Cierro el archivo
                sw.Close();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Método que leerá de un archivo .txt
        /// </summary>
        /// <param name="archivo"></param> Tipo string, ruta donde estará el archivo a leer
        /// <param name="datos"></param> out Tipo string, retornará los datos leídos
        /// <returns> bool retornará true si se pudo leer el archivo 
        /// de lo contrario retornará false </returns>
        public bool Leer(string archivo, out string datos)
        {
            if (File.Exists(archivo))
            {
                // Abro el archivo ubicado en una dirección de la máquina
                StreamReader sr = new StreamReader(archivo);

                // Leo un texto
                datos = sr.ReadToEnd();

                // Cierro el archivo
                sr.Close();
                return true; 
            }
            else
            {
                datos = string.Empty;
                return false;
            }
        }
    }
}
