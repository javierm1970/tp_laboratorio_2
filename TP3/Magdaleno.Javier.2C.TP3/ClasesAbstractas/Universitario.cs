using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntidadesAbstractas
{
    /// <summary>
    /// Clase abstracta derivada de la Clase Persona
    /// </summary>
    public abstract class Universitario : Persona
    {
        /// <summary>
        /// Atributo de la clase Universitario representa un legajo del Universitario
        /// </summary>
        private int legajo;
        /// <summary>
        /// Constructor sin parámetros que pasa valores por defecto a otro constructor de la Clase
        /// </summary>
        public Universitario()
            :this(0,"Sin nombre","Sin Apellido","0",ENacionalidad.Argentino)
        {
        }
        /// <summary>
        /// Costructor que pasa por parámetro los valores que recibe a la Clase Persona
        /// e inicializa el atributo legajo
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }

        #region Propiedades
        /// <summary>
        /// Propiedad que retorna o asigna un valor al atributo legajo
        /// Solo para que se agregue a la Serialización de Universidad
        /// </summary>
        public int Legajo
        {
            get
            {
                return this.legajo;
            }
            set
            {
                this.legajo = value;
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Sobreescritura del Método Equals
        /// que verifica si el objeto pasado es del mismo tipo que Universitario
        /// </summary>
        /// <param name="obj"></param> Tipo object
        /// <returns> bool retorna true si el objeto pasado es igual a la instancia
        /// false si no lo es o el objeto pasado es null </returns>
        public override bool Equals(object obj)
        {
            if (!(obj is null))
            {
                if (this.GetType()==obj.GetType())
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Sobreescritura del Método MostrarDatos()
        /// generara un string con los datos de un Universitario
        /// </summary>
        /// <returns> string que contiene los datos de un Universitario </returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.ToString());
            sb.AppendFormat("\nLEGAJO NúMERO: {0}", this.legajo);
            return sb.ToString();
        }
        /// <summary>
        /// Método abstract sin implementacion, obliga a las derivadas a implentarlo
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        #endregion

        #region Operadores
        /// <summary>
        /// Sobrecarga del operador == (Universitario Universitario)
        /// </summary>
        /// <param name="pg1"></param> Tipo Universitario
        /// <param name="pg2"></param> Tipo Universitario
        /// <returns>bool retornara true si el parametro 1 y el parametro 2
        /// son del mismo Type y si ademas conicide sus legajos o sus DNI
        /// de lo contrario devolverá false </returns>
        public static bool operator ==(Universitario pg1,Universitario pg2)
        {
            if (pg1.Equals(pg2) && (pg1.legajo==pg2.legajo || pg1.DNI == pg2.DNI))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Sobrecarga del operador != (Universitario Universitario)
        /// </summary>
        /// <param name="pg1"></param> Tipo Universitario
        /// <param name="pg2"></param> Tipo Universitario
        /// <returns>bool retornara true si el parametro 1 y el parametro 2
        /// no son del mismo Type o si conicide sus legajos o sus DNI
        /// de lo contrario devolverá false </returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return (!(pg1==pg2));
        }
        #endregion
    }
}
