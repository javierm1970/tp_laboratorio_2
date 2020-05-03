using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    /// <summary>
    /// La clase Automóvil Derivada de la Clase Base Vehiculo
    /// deberá permitir que se instancien elementos del tipo Automóvil.
    /// </summary>
    public class Automovil : Vehiculo
    {
        //Enumerado ETipo (tipo de Automoviles)
        public enum ETipo 
        { 
            Monovolumen, Sedan 
        }
        private ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será Monovolumen se pasan por parametro los atributos que 
        /// inicializara la Clase Base
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
            //por defecto ETipo tipo = ETipo.MonoVolumen (no se necesita asignar)
        }
        /// <summary>
        /// Constructor que inicializara el atributo tipo y pasara al otro constructor
        /// los datos que luego el segundo le pasara a la Base
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigo"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Automovil(EMarca marca, string codigo, ConsoleColor color, ETipo tipo)
            :this(marca,codigo, color)
        {
            this.tipo = tipo;
        }
        /// <summary>
        /// Propiedad de solo lectura que especifica el tamaño de Los automoviles (Medianos)
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return Vehiculo.ETamanio.Mediano;
            }
        }
        /// <summary>
        /// Mostrara los datos que obtenga del base.Mostrar() y
        /// ampliara con los valores del atributo (ETipo tipo) y la Propiedad Tamanio de esta Clase
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("\nTAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("\n---------------------");
            //sb.AppendLine("");
            return sb.ToString();
        }
    }
}
