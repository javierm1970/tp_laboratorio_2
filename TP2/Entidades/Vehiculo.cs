using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        //Enumerador de Marcas
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda
        }
        //Enumerador de Tamanios
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }
        //Atributos de la Clase Vehiculos
        private EMarca marca;
        private string chasis;
        private ConsoleColor color;
        //Constructor que inicializa los Atributos de la Clase
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.color = color;
            this.marca = marca;
        }
        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio { get; }

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        /// <summary>
        /// Realiza una conversion explicita donde el Objeto Vehiculo p 
        /// se retorna como un string que contiene los valores de sus atributos
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat ("CHASIS: {0}\r\n", p.chasis);
            sb.AppendFormat ("MARCA : {0}\r\n", p.marca.ToString());
            sb.AppendFormat ("COLOR : {0}\r\n", p.color.ToString());
            sb.AppendFormat ("---------------------");

            return sb.ToString();
        }
        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
    }
}
