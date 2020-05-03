using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Moto Derivada de la Clase Base Vehiculo
    /// deberá permitir que se instancien elementos del tipo Moto.
    /// </summary>
    public class Moto : Vehiculo
    {
        public Moto(Vehiculo.EMarca marca, string chasis, ConsoleColor color)
            :base(chasis,marca,color)
        {
        }

        /// <summary>
        /// Propiedad de solo lectura que especifica el tamaño de Las Motos (Chico)
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return Vehiculo.ETamanio.Chico;
            }
        }
        /// <summary>
        /// Mostrara los datos que obtenga del base.Mostrar() y
        /// ampliara con el valor de la Prpiedad Tamanio de esta Clase
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("\nTAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("\n---------------------");

            return sb.ToString();
        }
    }
}
