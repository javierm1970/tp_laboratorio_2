using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using InterfazMostrar;
using Excepciones;

namespace Entidades
{
    /// <summary>
    /// Clase Correo implementa la Interface IMostras<list<Paquete>>"
    /// </summary>
    public class Correo : IMostrar<List<Paquete>>
    {
        // Atributos privados de la Clase correo, Lista paquetes y lista de Hilos
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        /// <summary>
        /// Constructor público y sin parámetros que inicializa las atributos listas de la clase
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }
        /// <summary>
        /// Obtiene un objeto <param> List </param> de paquetes.
        /// Devuelve un objeto list de paquetes
        /// </summary>
        public List<Paquete> Paquete
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        /// <summary>
        /// Cierra todos los hilos incluidos en una Lista
        /// </summary>
        public void FinEntregas()
        {
            if (!(this.mockPaquetes is null))
            {
                foreach (Thread item in this.mockPaquetes)
                {
                    if (item.IsAlive)
                    {
                        item.Abort();
                    }
                }
            }
        }
        /// <summary>
        /// Devuelve todos los datos de cada paquete de una lista pasada como parámetro
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns> string </returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();

            if (!(elementos is null))
            {
                foreach (Paquete item in ((Correo)elementos).Paquete)
                {
                    sb.AppendLine(string.Format("{0} para {1} {2}",
                        item.TrackingID, item.DireccionEntrega, item.Estado));
                } 
            }
            
            return sb.ToString();
        }
        /// <summary>
        /// Incorpora un paquete a la lista si no existe previamente.
        /// Crea un hilo y lo ejecuta, el hilo representa el ciclo de vida del paquete.
        /// Si el paquete existe se lanzara la Exception: TrackingIDRepetidoException()
        /// </summary>
        /// <param name="c"></param> Tipo Correo
        /// <param name="p"></param> Tipo Paquete
        /// <returns> Tipo Correo </returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            try
            {
                if (!(c is null) && !(p is null))
                {
                    foreach (Paquete item in c.Paquete)
                    {
                        if (item.TrackingID == p.TrackingID)
                        {
                            throw new TrackingIDRepetidoException();
                        }
                    }
                    c.Paquete.Add(p);
                    Thread hiloMockCicloDeVida = new Thread(p.MockCicloDeVida);
                    c.mockPaquetes.Add(hiloMockCicloDeVida);
                    hiloMockCicloDeVida.Start();
                }
            }
            catch (SqlReadOrWriteException ex)
            {
                throw ex;
            }
            return c;
        }
    }
}
