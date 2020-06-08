using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magdaleno.Javier._2C.TP3
{
    /// <summary>
    /// Clase Universidad contiene como atributo la lista de alumnos, profesores y jornadas
    /// </summary>
    public class Universidad
    {
        /// <summary>
        /// Enumerado que contiene la lista de clases universitarias
        /// </summary>
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }
        /// <summary>
        /// Atributos de la Clase Universidad, lista de alumnos, jornadas y profesores
        /// </summary>
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        /// <summary>
        /// Constructor sin parámetros que inicializa las listas de alumnos, jornadas y profesores
        /// </summary>
        public Universidad()
        {
            alumnos = new List<Alumno>();
            jornada = new List<Jornada>();
            profesores = new List<Profesor>();
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
        /// Propiedad Instructores, devuelve o incorpora una lista de Profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        /// <summary>
        /// Propiedad Jornadas, devuelve o incorpora una lista de Jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        /// <summary>
        /// Indexador que devuelve una determinada jornada de la lista por su indice
        /// o incorpora en dicho indice una jornada en la lista
        /// </summary>
        /// <param name="i"></param> Tipo int indice de la jornada a devolver o insertar
        /// <returns> Jornada, una jornada determinada dentro de una lista de Jornadas </returns>
        public Jornada this[int i]
        {
            get 
            {
                if (i >0 && i < this.jornada.Count)
                {
                    return this.jornada.ElementAt(i); 
                }
                return default(Jornada);
            }
            set 
            {
                if (i > 0 && i < this.Jornadas.Count)
                {
                    this.jornada.Insert(i, value); 
                } 
            }
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Sobreescritura del Método ToString()
        /// hace públicos los datos de la Universidad, todas las jornadas de la lista
        /// con sus respectivos profesores y alumnos
        /// </summary>
        /// <returns> string con los datos de la Universidad, sus jornadas,
        /// profesores y alumnos </returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        /// <summary>
        /// Método static Especifica la ruta y el archivo .xml, 
        /// donde se van a guardar los datos de la Universidad 
        /// </summary>
        /// <param name="uni"></param> Tipo Universidad, variable de donde se van a tomar los datos
        /// <returns> bool, si el archivo pudo ser creado y escrito retornara true
        /// de lo contrario false </returns>
        public static bool Guardar(Universidad uni)
        {
            string miPath = string.Format(@"D:\prueba Archivos\Universidad.xml");
            Xml<Universidad> reporteUniversidad = new Xml<Universidad>();
            if (reporteUniversidad.Guardar(miPath, uni))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Método static Especifica la ruta y el archivo .xml, 
        /// de donde se van a leer los datos de la Universidad 
        /// </summary>
        /// <returns> Universidad, si el archivo pudo ser leido e incorporado 
        /// null si no fue posible </returns>
        public static Universidad Leer()
        {
            string miPath = string.Format(@"D:\prueba Archivos\Universidad.xml");
            Universidad auxUniversidad;

            Xml<Universidad> reporteUniversidad = new Xml<Universidad>();
            if (reporteUniversidad.Leer(miPath,out auxUniversidad))
            {
                return auxUniversidad;
            }
            return default(Universidad);
        }
        /// <summary>
        /// Metodo private static
        /// Crea un string con los datos de la Universidad, cada una de sus Jornadas
        /// </summary>
        /// <param name="uni"></param> Tipo Universidad especifica una Universidad
        /// <returns> string con los datos de la Universidad </returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");
            foreach (Jornada item in uni.Jornadas)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Sobrecarga del operador + (Universidad Alumno)
        /// </summary>
        /// <param name="u"></param> Tipo Universidad
        /// <param name="a"></param> Tipo Alumno
        /// <returns> Universidad con los datos del alumno incorporado
        /// a la lista Alumnos de la Universidad.
        /// si el alumno ya existe en la lista lanzará una Excepcion AlumnoRepetidoException </returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (!(u == a))
            {
                u.alumnos.Add(a);
                return u;
            }
            throw new AlumnoRepetidoException("Alumno Repetido.");
        }
        /// <summary>
        /// Sobrecarga del operador + (Universidad Profesor)
        /// </summary>
        /// <param name="u"></param> Tipo Universidad
        /// <param name="i"></param> Tipo Profesor
        /// <returns> Universidad si el porfesor no estaba en la lista de profesores
        /// de lo contrario una retornara null </returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (!(u == i))
            {
                u.profesores.Add(i);
                return u;
            }
            return default(Universidad);
        }
        /// <summary>
        /// Sobrecarga del operador + (Universidad / Enumerado EClases)
        /// </summary>
        /// <param name="g"></param> Tipo Universidad
        /// <param name="clase"></param> Tipo Enumerado EClases
        /// <returns> Universidad que contendra una nueva jornada si existen profesores
        /// para una clase determinada (EClases)
        /// de lo contrario devolvera la misma Universidad pasada como parámetro </returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor auxProfesor = (g == clase);
            if (!(auxProfesor is null))
            {
                Jornada auxJornada = new Jornada(clase, auxProfesor);

                foreach (Alumno item in g.Alumnos)
                {
                    if (item==clase)
                    {
                        auxJornada += item;
                    }
                }
                g.Jornadas.Add(auxJornada);
            }
            return g;
        }
        /// <summary>
        /// Sobrecarga del operador == (Univeridad Alumno)
        /// </summary>
        /// <param name="g"></param> Tipo Universidad
        /// <param name="a"></param> Tipo Alumno
        /// <returns> bool retornara true si el alumno pudo ser incorporado
        /// a la lista alumnos de la universidad
        /// false, si el alumno ya estaba dentro de la lista </returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            if (!(a is null))
            {
                foreach (Alumno item in g.Alumnos)
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
        /// Sobrecarga del operador == (Universidad Profesor)
        /// </summary>
        /// <param name="g"></param> Tipo Universidad
        /// <param name="i"></param> Tipo Profesor
        /// <returns> bool retornara true si el profesor pudo ser incorporado
        /// a la lista profesores de la universidad
        /// false, si el profesor ya estaba dentro de la lista </returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            if (!(i is null))
            {
                foreach (Profesor item in g.profesores)
                {
                    if (item == i)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Sobrecarga del operador == (Universidad / Enumerado EClase)
        /// </summary>
        /// <param name="u"></param> Tipo Universidad
        /// <param name="clase"></param> Tipo Enumerado EClases
        /// <returns> Profesor si el profesor dicta esa clase 
        /// de lo contrario lanzara una Excepcion SinProfesorException </returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.profesores)
            {
                if (item == clase)
                {
                    return item;
                }
            }
            throw new SinProfesorException("No hay Profesor para la clase.");
        }
        /// <summary>
        /// Sobrecarga del operador != (Univeridad Alumno)
        /// </summary>
        /// <param name="g"></param> Tipo Universidad
        /// <param name="a"></param> Tipo Alumno
        /// <returns> bool retornara true si el alumno no pudo ser incorporado
        /// a la lista alumnos de la universidad
        /// false, si el alumno pudo ser incorporado a la lista </returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return (!(g==a));
        }
        /// <summary>
        /// Sobrecarga del operador != (Universidad Profesor)
        /// </summary>
        /// <param name="g"></param> Tipo Universidad
        /// <param name="i"></param> Tipo Profesor
        /// <returns> bool retornara true si el profesor no pudo ser incorporado
        /// a la lista profesores de la universidad
        /// false, si el profesor si pudo ser incorporado a la lista </returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return (!(g==i));
        }
        /// <summary>
        /// Sobrecarga del operador != (Universidad / Enumerado EClase)
        /// </summary>
        /// <param name="u"></param> Tipo Universidad
        /// <param name="clase"></param> Tipo Enumerado EClases
        /// <returns> Profesor el primer profesor que no dicte esa clase 
        /// de lo contrario retornara un Profesor null </returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.profesores)
            {
                if (!(item == clase))
                {
                    return item;
                }
            }
            return null;
        }

        #endregion
    }
}
