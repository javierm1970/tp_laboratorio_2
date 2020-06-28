using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfazMostrar;
using System.Threading;
using Excepciones;

namespace Entidades
{
    /// <summary>
    /// Clase Paquete que implementa la Interface IMostrar<Paquete>
    /// </summary>
    public class Paquete : IMostrar<Paquete>
    {
        /// <summary>
        /// Enumerador de estados de un paquete
        /// </summary>
        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        }
        //Atributos de la Clase Paquete
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        public event DelegadoEstado InformaEstado;
        public delegate void DelegadoEstado(object sender, EventArgs e);
        /// <summary>
        /// Constructor de la Clase Paquete
        /// </summary>
        /// <param name="direccionEntrega"></param> string direccion de entrega
        /// <param name="trackingID"></param> string id del tracking
        public Paquete(string direccionEntrega,string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.Ingresado;
        }
        /// <summary>
        /// Obtiene o Devuelve la direccion de entrega del paquete
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }
        /// <summary>
        /// Obtiene o Devuelve el estado actual del paquete
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado; 
            }
            set
            {

                this.estado = value;
            }
        }
        /// <summary>
        /// Obtiene o devuelve el id del tracking del paquete
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }
        /// <summary>
        /// Simulador del ciclo de vida de un paquete, cada 4 segundos se lanza un evento 
        /// luego de un cambio de estado automatico. el evento informa del cambio de estado y 
        /// reimprime la informacion en la pantalla.
        /// finalmente insertará el paquete a la base de datos.
        /// </summary>
        public void MockCicloDeVida()
        {
            Thread.Sleep(4000);
            this.estado = EEstado.EnViaje;
            InformaEstado.Invoke(this, new EventArgs());
            
            Thread.Sleep(4000);
            this.estado = EEstado.Entregado;
            InformaEstado.Invoke(this, new EventArgs());
            PaqueteDAO.Insertar(this);
        }
        /// <summary>
        /// Retornará un string con la información de un objeto paquete
        /// </summary>
        /// <param name="elementos"></param> objeto paquete
        /// <returns> string </returns>
        public string MostrarDatos (IMostrar<Paquete> elementos)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n");
            sb.AppendLine("Informacion del Paquete");
            sb.AppendFormat("IDTracking: {0} \nDirección: {1} \nEstado: {2}",
                ((Paquete)elementos).TrackingID, ((Paquete)elementos).DireccionEntrega,
                ((Paquete)elementos).estado);
            sb.Append("\n");

            return sb.ToString();
        }
        /// <summary>
        /// Sobreescritura del Método ToString() 
        /// </summary>
        /// <returns> string que representa el "id del tracking" y la "direccion destino" </returns>
        public override string ToString()
        {
            return string.Format("{0} para {1}", this.trackingID, this.direccionEntrega);
        }
        /// <summary>
        /// Verifica si dos paquetes tienen el mismo id de tracking
        /// </summary>
        /// <param name="p1"></param> objeto Paquete
        /// <param name="p2"></param> objeto Paquete
        /// <returns> true si son iguales, false si no lo son </returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool retorno = false;
            if (!(p1 is null) && !(p2 is null))
            {
                if (p1.TrackingID == p2.TrackingID)
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Verifica si dos paquetes tienen distinto id de tracking
        /// </summary>
        /// <param name="p1"></param> objeto Paquete
        /// <param name="p2"></param> objeto Paquete
        /// <returns> false si son iguales, true si no lo son </returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return (!(p1==p2));
        }
    }
}
