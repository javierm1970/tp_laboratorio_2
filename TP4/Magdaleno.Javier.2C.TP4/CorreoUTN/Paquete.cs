using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfazMostrar;
using System.Threading;



namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        }
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        public event DelegadoEstado InformaEstado;
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public Paquete(string direccionEntrega,string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.Ingresado;
        }
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
        public override string ToString()
        {
            return string.Format("{0} para {1}", this.trackingID, this.direccionEntrega);
        }
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
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return (!(p1==p2));
        }
    }
}
