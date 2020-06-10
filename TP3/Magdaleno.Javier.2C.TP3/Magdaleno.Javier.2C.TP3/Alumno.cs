using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    /// <summary>
    /// Clase Alumno que es derivada de la clase Universitario
    /// </summary>
    public sealed class Alumno : Universitario
    {
        /// <summary>
        /// Enumerado del estado de cuenta
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }
        /// <summary>
        /// Atributos de la clase Alumnos
        /// </summary>
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        /// <summary>
        /// Costructor sin parámetros que inicializa con valores por default los atributos
        /// </summary>
        public Alumno():
            this(0,"Sin Nombre","Sin Apellido","1",
                ENacionalidad.Argentino,Universidad.EClases.Laboratorio)
        {
        }
        /// <summary>
        /// Constuctor de la Clase Alumnos 
        /// </summary>
        /// <param name="id"></param> Corresponde con el legajo
        /// <param name="nombre"></param> 
        /// <param name="apellido"></param>
        /// <param name="dni"></param> corresponde con el numero de identidad
        /// <param name="nacionalidad"></param> 
        /// <param name="claseQueToma"></param> representa en que clase esta inscripto el alumno
        public Alumno(int id, string nombre, string apellido, string dni,
            ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :this(id,nombre, apellido,dni,nacionalidad,claseQueToma,EEstadoCuenta.AlDia)
        {
        }
        /// <summary>
        /// Constructor de la Clase Alumno
        /// </summary>
        /// <param name="id"></param> Corresponde con el legajo
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param> Corresponde con el numero de identidad
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param> representa en que clase esta inscripto el alumno
        /// <param name="estadoCuenta"></param> Condicion en que se encuentra frente a la cuota 
        public Alumno(int id, string nombre, string apellido, string dni,
            ENacionalidad nacionalidad, Universidad.EClases claseQueToma,EEstadoCuenta estadoCuenta)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
            this.estadoCuenta = estadoCuenta;
        }

        #region Métodos

        /// <summary>
        /// Sobreescritura del Metodo protegido MostrarDatos()
        /// muestra los datos de un Alumno
        /// </summary>
        /// <returns> string con los Datos de un Alumno </returns> 
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            string cuotaAlDia=this.estadoCuenta.ToString();
            if (this.estadoCuenta == 0)
                cuotaAlDia = "Cuota al día";

            sb.AppendFormat("NOMBRE COMPLETO: {0}", base.MostrarDatos());
            sb.Append("\n");
            sb.AppendFormat("\nESTADO DE CUENTA: {0}", cuotaAlDia);
            sb.AppendFormat("\n{0}",this.ParticiparEnClase());

            return sb.ToString();
        }
        /// <summary>
        /// Sobreescritura del Metodo protegido ParticipaEnClase()
        /// muestra el dato referido a que clase esta cursando
        /// </summary>
        /// <returns> string con los datos de la clase en la que esta inscripto</returns>
        protected override string ParticiparEnClase()
        {
            return string.Format("TOMA CLASE DE {0}",this.claseQueToma);
        }
        /// <summary>
        /// Sobreescritura del Método ToString()
        /// hace público los datos de un determinado Alumno
        /// </summary>
        /// <returns> string con los datos que posee el alumno </returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Operator
        /// <summary>
        /// Sobrecarga del operador ==
        /// </summary>
        /// <param name="a"></param> objeto del tipo Alumno
        /// <param name="clase"></param> variable q contiene un valor del Enumerado EClase
        /// <returns> bool, si el alumno toma la clase retorna true, sino false  </returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma==clase && !(a.estadoCuenta == EEstadoCuenta.Deudor))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Sobrecarga del operador !=
        /// </summary>
        /// <param name="a"></param> objeto del tipo Alumno
        /// <param name="clase"></param> variable q contiene un valor del Enumerado EClase
        /// <returns> bool si el alumno no toma la clase retorna true si la toma false </returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (!(a==clase));
        }
        
        #endregion
    }
}
