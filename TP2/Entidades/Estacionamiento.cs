using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Estacionamiento
    {
        //Atributos de la Clase Estacionamiento
        private List<Vehiculo> vehiculos;
        private int espacioDisponible;
        
        //Enumerador anidado en la clase Estacionamiento
        public enum ETipo
        {
            Moto, Automovil, Camioneta, Todos
        }

        #region "Constructores"
        //Constructor que inicializa la Lista vehiculo
        private Estacionamiento()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        //Constructor que inicializa los atributos de la Clase
        public Estacionamiento(int espacioDisponible):this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Estacionamiento c, ETipo tipo)
        {
            //declaracion de una variable ETipo q sirve para filtrar en el foreach (tipo) a imprimir en pantalla
            ETipo tipoVerifica=tipo;

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c.vehiculos.Count, c.espacioDisponible);
            sb.AppendLine("");

            foreach (Vehiculo v in c.vehiculos)
            {
                if (v is Moto)
                {
                    tipoVerifica = ETipo.Moto;
                }
                else if (v is Automovil)
                {
                    tipoVerifica = ETipo.Automovil;
                }
                else if (v is Camioneta)
                {
                    tipoVerifica = ETipo.Camioneta;
                }

                if (tipo == ETipo.Todos || tipo==tipoVerifica)
                {
                    sb.AppendLine(v.Mostrar());
                //Se quita el Switch Todas las opciones hacen lo mismo    
                }
            }
            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Estacionamiento operator +(Estacionamiento c, Vehiculo p)
        {
            foreach (Vehiculo v in c.vehiculos)
            {
                if (c.vehiculos.Count >= c.espacioDisponible || v == p )
                    return c; 
            }
            c.vehiculos.Add(p);
            return c;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Estacionamiento operator -(Estacionamiento c, Vehiculo p)
        {
            bool flagSalida;
            
            do
            {
                int i=0;
                flagSalida = false;
                foreach (Vehiculo v in c.vehiculos)
                {
                    if (v == p)
                    {
                        c.vehiculos.RemoveAt(i);
                        flagSalida = true;
                        break;
                    }
                }

            } while (flagSalida);
            
            return c;
        }
        #endregion
    }
}
