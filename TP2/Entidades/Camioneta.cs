using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Camioneta Derivada de la Clase Base Vehiculo
    /// deberá permitir que se instancien elementos del tipo Camioneta.
    /// </summary>
    public class Camioneta : Vehiculo
    {
        /// <summary>
        /// Constructor que pasara los valores para que los inicialice la Clase Base
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Camioneta(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
        /// <summary>
        /// Propiedad de solo lectura que especifica el tamaño de Las Camionetas (Grandes)
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return Vehiculo.ETamanio.Grande;
            }
        }
        /// <summary>
        /// Mostrara los datos que obtenga del método de conversion explicita que contiene la base y
        /// ampliara con el valor de la Propiedad Tamanio de esta Clase
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMIONETA");
            sb.AppendFormat((string)this);
            sb.AppendLine("");
            sb.AppendFormat("\nTAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("\n---------------------");
            return sb.ToString();
        }
    }
}
