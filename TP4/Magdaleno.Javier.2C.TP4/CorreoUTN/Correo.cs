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
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }
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
        public static Correo operator +(Correo c, Paquete p)
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
            return c;
        }
    }
}
