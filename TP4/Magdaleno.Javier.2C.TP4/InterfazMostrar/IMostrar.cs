using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazMostrar
{
    //Interface con un metodo para que implementen las clases que se suscriban 
    public interface IMostrar<T>
    {
        /// <summary>
        /// Metodo a implementar por las clase que se suscriban a la Interface IMostrar Genérico T
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns>string</returns>
        string MostrarDatos(IMostrar<T> elementos);
    }
}
