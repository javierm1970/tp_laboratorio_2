using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas

{
    /// <summary>
    /// Clase abstrac Persona
    /// </summary>
    public abstract class Persona
    {
        /// <summary>
        /// Enumerado que contiene nacionalidades del Tipo ENacionalidad
        /// </summary>
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
        /// <summary>
        /// Atributos de la Clase Persona 
        /// </summary>
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        /// <summary>
        /// Constructor sin parámetros que inicializa con valores por defecto los
        /// atributos de la Clase Persona
        /// </summary>
        public Persona()
            :this("Sin nombre","Sin Apellido",0,ENacionalidad.Argentino)
        {
        }
        /// <summary>
        /// Constructor que pasa mediante parametros a otro constructor
        /// los valores para nombre, apellido, un dni por defecto y una nacionalidad
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            :this(nombre,apellido,0,nacionalidad)
        {
        }
        /// <summary>
        /// Constructor que inicializa mediante propiedades los valores de los 
        /// atributos de la Clase Persona
        /// </summary>
        /// <param name="nombre"></param> Tipo string representa el nombre de la persona
        /// <param name="apellido"></param> Tipo string representa el apellido de la persona
        /// <param name="dni"></param> Tipo int representa el numero de identidad de una persona
        /// <param name="nacionalidad"></param> Tipo ENacionalidad representa la nacionalidad
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.DNI = dni;
            this.Nacionalidad = nacionalidad;
            
        }
        /// <summary>
        /// Costructor que pasa por parametros a otro constructor los datos de nombre, apellido
        /// un dni por defecto del Tipo int e inicializa mediante la Propiedad StringToDni el 
        /// atributo dni de la Clase
        /// </summary>
        /// <param name="nombre"></param> Tipo string representa el nombre de la persona
        /// <param name="apellido"></param> Tipo string representa el apellido de la persona
        /// <param name="dni"></param> Tipo string representa el numero de identidad de la persona
        /// <param name="nacionalidad"></param> Tipo ENacionalidad representa la nacionalidad
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :this(nombre, apellido, 1 ,nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #region Propiedades

        /// <summary>
        /// Propiedad Apellido devuelve o incorpora un apelldio al atributo apellido
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                if (value == this.ValidarNombreApellido(value))
                {
                    this.apellido = value;
                }
            }
        }
        /// <summary>
        /// Propiedad DNI devuelve o incorpora un valor al atributo dni de la Clase Persona
        /// luego de valiar el mismo, si el dni no corresponde con la nacionalidad
        /// lanzara una Excepción : NacionalidadInvalidaException
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                try
                {
                    if (value == this.ValidarDni(this.nacionalidad, value))
                    {
                        this.dni = value;
                    }
                }
                catch (NacionalidadInvalidaException e)
                {
                    throw e;
                }
            }
        }
        /// <summary>
        /// Propiedad Nacionalidad devolvera o incorpora un valor al atributo nacionalidad
        /// del Tipo ENacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        /// <summary>
        /// Propiedad Nombre devolvera o incorporará un valor al atributo nombre
        /// luego de validar que el valor asigndo no contenga caracteres inválidos
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                if (value == this.ValidarNombreApellido(value))
                {
                    this.nombre = value;
                }
            }
        }
        /// <summary>
        /// Propiedad set; StringToDNI convertirá el string asignado como valor
        /// en un int válido y lo pasara a la propiedad DNI para que lo incorpore
        /// </summary>
        public string StringToDNI
        {
            set
            {
                try
                {   
                    int resultado = this.ValidarDni(this.nacionalidad,value);
                    this.DNI = resultado;
                }
                catch (NacionalidadInvalidaException e)
                {
                    throw new NacionalidadInvalidaException(e.Message);
                }

                this.DNI = int.Parse(value);
            }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Sobreescritura del Método ToString()
        /// Hará publico los datos de una Persona
        /// </summary>
        /// <returns> string que contendra los datos de una Persona </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}, {1}", this.Apellido, this.Nombre);
            sb.AppendLine(string.Format("\nNACIONALIDAD: {0}",this.Nacionalidad));
            return sb.ToString();
        }

        #endregion

        #region Validaciones

        /// <summary>
        /// Método que validará si un rando de DNI corresponde con una Nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param> Tipo ENacionalidad Enumerado
        /// <param name="dato"></param> Tipo int 
        /// <returns> int que representa un DNI valido 
        /// de lo contrario lanzará una Excepción del Tipo NacionalidadInvalidaException </returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if ((dato >0 && dato <= 89999999) && nacionalidad==ENacionalidad.Argentino)
            {
                return dato;
            }
            else if ((dato >= 90000000 && dato <= 99999999) && nacionalidad == ENacionalidad.Extranjero)
            {
                return dato;
            }
            else
            {
                throw new NacionalidadInvalidaException(
                    "La Nacionalidad no se condice con el número de DNI");
            }
        }
        /// <summary>
        /// Método que validará si un string dato es convertible a un int y
        /// si éste es de un tamaño mayor a 0 y menor o igual a 8 
        /// </summary>
        /// <param name="nacionalidad"></param> Tipo ENacionalidad Enumerado
        /// <param name="dato"></param> Tipo string
        /// <returns> int que representa el valor de un DNI válido
        /// o caso contrario lanzará una Excepción del Tipo DniInvalidoException </returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int resultado;

            if (!(int.TryParse(dato,out resultado))
                || dato.Length <= 0 || dato.Length > 8)
            {
                throw new DniInvalidoException("DNI Ingresado no es un número válido");
            }
            resultado = this.ValidarDni(nacionalidad, resultado);

            return resultado;
        }
        /// <summary>
        /// Método que validará si un string no contiene caracteres inválido para un 
        /// nombre o un apellido
        /// </summary>
        /// <param name="dato"></param> Tipo string
        /// <returns> retorna un string con un apellido o nombre válido 
        /// o caso contrario un string Empty </returns>
        private string ValidarNombreApellido(string dato)
        {
            char aux;

            for (int i = 0; i < dato.Length; i++)
            {
                aux = char.ToLower(dato[i]);

                if (((int)aux >= 97 && (int)aux <=122) ||
                    ((int)aux >= 160 && (int)aux <= 163) ||
                        (int)aux == 130 || (int)aux == 165)
                {
                    continue;
                }
                else
                {
                    dato=string.Empty;
                    break;
                }
            }
            return dato;
        }

        #endregion
    }
}
