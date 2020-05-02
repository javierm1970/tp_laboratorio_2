using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Automovil : Vehiculo
    {
        public enum ETipo 
        { 
            Monovolumen, Sedan 
        }
        private ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será Monovolumen
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
            
        }
        public Automovil(EMarca marca, string codigo, ConsoleColor color, ETipo tipo)
            :this(marca,codigo, color)
        {
            this.tipo = tipo;
        }
        /// <summary>
        /// Los automoviles son medianos
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return Vehiculo.ETamanio.Mediano;
            }
        }

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
