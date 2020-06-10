using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    /// <summary>
    /// Clase Jornada representa una clase universitaria donde se especifican los siguientes datos:
    /// nombre del profesor a cargo, nombre de la clase y alumnos que participan
    /// </summary>
    public class Jornada
    {
        /// <summary>
        /// Atributos de la Clase Jornada, Profesor, clase y lista de alumnos
        /// </summary>
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        /// <summary>
        /// Constructor que inicializa la lista de Alumnos 
        /// </summary>
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Constructor que inicializa los atributos Tipo Profesor instructor y Tipo EClase clase
        /// </summary>
        /// <param name="clase"></param> Enumerado EClase
        /// <param name="instructor"></param> Tipo Profesor
        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        #region Propiedades
        /// <summary>
        /// Propiedad Alumnos devuelve o incorpora una lista de Alumnos 
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        /// <summary>
        /// devuelve o incorpora un valor a la variable clase del Tipo Enumerado EClases 
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }
        /// <summary>
        /// devuelve o incorpora un valor a la variable de Tipo Profesor instructor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Método static 
        /// encargado de configurar el path y el nombre de archivo donde se
        /// guardaran los datos de una jornada
        /// </summary>
        /// <param name="jornada"></param> Tipo Jornada
        /// <returns> bool, si se guardaro el archivo retorna true, de lo contrario false </returns>
        public static bool Guardar(Jornada jornada)
        {
            string miPath = string.Format("{0}{1}",
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "\\jornada.txt");

            if (!(jornada is null))
            {
                Texto texto = new Texto();
                if (texto.Guardar(miPath, jornada.ToString()))
                {
                    return true;
                }
            }
            return false; 
        }
        /// <summary>
        /// Método static
        /// encargado de configurar el path y el nombre de archivo de donde se
        /// leerán los datos de una jornada
        /// </summary>
        /// <returns> bool, si se pudo leer el archivo retornara true, sino false </returns>
        public static string Leer()
        {
            string miPath = string.Format("{0}{1}",
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "\\jornada.txt");
            string textoLeido;
            Texto texto = new Texto();
            if (texto.Leer(miPath,out textoLeido))
            {
                return textoLeido;
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// Sobreescritura del Método ToString()
        /// hace público los datos de una Jornada
        /// </summary>
        /// <returns> string con los datos de una Jornada </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("JORNADA:");
            sb.AppendFormat("CLASE DE {0} POR NOMBRE COMPLETO: {1}",
                this.clase, this.Instructor.ToString());
            sb.AppendFormat("ALUMNOS: \n");
            foreach (Alumno item in this.Alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("<------------------------------------------------------------>");
            return sb.ToString();
        }
        #endregion

        #region Operator
        /// <summary>
        /// Sobrecarga del operadot == 
        /// </summary>
        /// <param name="j"></param> Tipo Jornada
        /// <param name="a"></param> Tipo Alumno
        /// <returns> bool, si el alumno se encuentra en la lista de Alumnos de la jornada 
        /// false si no lo está </returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            if (!(j is null))
            {
                foreach (Alumno item in j.Alumnos)
                {
                    if (item == a)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Sobrecarga del operadot != 
        /// </summary>
        /// <param name="j"></param> Tipo Jornada
        /// <param name="a"></param> Tipo Alumno
        /// <returns> bool, si el alumno no se encuentra en la lista de Alumnos de la jornada 
        /// false si lo está </returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return (!(j==a));
        }
        /// <summary>
        /// Sobrecarga del operador +
        /// </summary>
        /// <param name="j"></param> Tipo Jornada
        /// <param name="a"></param> Tipo Alumno
        /// <returns> Jornada, con el alumno cargado si el mismo no existia en la lista </returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (!(j is null))
            {
                if (!(j == a))
                {
                    j.Alumnos.Add(a);
                }
            }
            return j;
        }
        #endregion
    }
}
