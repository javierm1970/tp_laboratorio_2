using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Archivos
{
    public class Xml<T> : IArchivos<T>
    {
        /// <summary>
        /// Método que escribe un archivo .xml
        /// </summary>
        /// <param name="archivo"></param> Tipo string ruta del archivo a guardar
        /// <param name="datos"></param> Tipo T (genérico) datos que se van a escribir en el archivo
        /// <returns> bool retornará true si se escribio el archivo 
        /// de lo contrario retornará false </returns>
        public bool Guardar(string archivo, T datos)
        {
            XmlTextWriter writer = null;
            try
            {
                writer = new XmlTextWriter(archivo, Encoding.UTF8);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, datos);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (!object.ReferenceEquals(writer, null))
                    writer.Close();
            }
        }
        /// <summary>
        /// Método que leerá un archivo .xml
        /// </summary>
        /// <param name="archivo"></param> Tipo string, ruta donde estará el archivo a leer
        /// <param name="datos"></param> out Tipo T (genérico), retornará los datos leídos
        /// <returns> bool retornará true si se pudo leer el archivo 
        /// de lo contrario retornará false </returns>
        public bool Leer(string archivo, out T datos)
        {
            XmlTextReader writer = null;
            try
            {
                writer = new XmlTextReader(archivo);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                datos = (T)serializer.Deserialize(writer);
                writer.Close();

                return true;
            }
            catch (Exception)
            {
                datos = default(T);
                return false;
            }
            finally
            {
                if (!object.ReferenceEquals(writer, null))
                    writer.Close();
            }
        }
    }
}
