using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Magdaleno.Javier._2C.TP3
{
    /// <summary>
    /// Clase Profesor derivada de la Clase universitario
    /// </summary>
    public sealed class Profesor : Universitario
    {
        /// <summary>
        /// Atributos de la Clase, private Queue <Universidad.EClases> claseDelDia 
        /// private static random valor random que determina que clases toma el profesor
        /// </summary>
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        /// <summary>
        /// Constructor sin parámetros que inicializa el valor de la variable random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }
        /// <summary>
        /// Constructor sin parámetros que inicializa los atributos con valores por defecto
        /// </summary>
        public Profesor():this(0,"SinNombre","SinApellido","1",Persona.ENacionalidad.Argentino)
        {
        }
        /// <summary>
        /// Constructor a los que se le pasan los valores para inicializar los atributos de la 
        /// clase Profesor
        /// </summary>
        /// <param name="id"></param> Tipo int que representa el legajo
        /// <param name="nombre"></param> Tipo string que representa el nombre del profesor
        /// <param name="apellido"></param> Tipo string que representa el apellido del profesor
        /// <param name="dni"></param> Tipo string que representa el numero de identidad del profesor
        /// <param name="nacionalidad"></param> Tipo string que representa la nacionalidad del profesor
        public Profesor(int id, string nombre, string apellido,
            string dni, ENacionalidad nacionalidad)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        #region Métodos

        /// <summary>
        /// Método que incorpora dos elementos clasesDelDia, al azar, en la Cola que contiene
        /// las clase en las que el profesor estara como titular
        /// </summary>
        private void _randomClases()
        {
            int indice;
            for (int i = 0; i < 2; i++)
            {
                indice = random.Next(0,3);
                this.clasesDelDia.Enqueue((Universidad.EClases)indice); 
            }
        }
        /// <summary>
        /// Sobreescritura Método protegido MostrarDatos()
        /// que muestra los datos de un profesor 
        /// </summary>
        /// <returns> string con los datos del profesor incluido las clases en las 
        /// que es titular </returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASE DE {0} POR NOMBRE COMPLETO: {1}",
                base.MostrarDatos(),this.ParticiparEnClase());

            return sb.ToString();
        }
        /// <summary>
        /// Sobreescritura del Método protegido ParticipaEnClase() 
        /// muetra las clase donde el profesor es titular
        /// </summary>
        /// <returns> string que muestra las clases donde el profesor es titular </returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DÍA:");
            if (!(this.clasesDelDia is null))
            {
                foreach (Universidad.EClases item in this.clasesDelDia)
                {
                    sb.AppendLine(item.ToString());
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// Sobreescritura del método ToString() 
        /// hace público los datos tanto del profesor, como las clases en que es titular
        /// </summary>
        /// <returns> string que muestra los datos del profesor y sus clases </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }
        #endregion

        #region Operator
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            if (i.clasesDelDia.Contains(clase))
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return (!(i==clase));
        }

        #endregion
    }
}
