using Entidades;
using Excepciones;
using Extensiones;
using InterfazMostrar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormCorreoUTN
{
    // Formulario Principal 
    public partial class FrmPpal : Form
    {
        // Atributos del formulario, path por defecto y un objeto de la clase Correo
        private AppDomain currentDomain;
        private Correo correo;
        public static string miPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        /// <summary>
        /// Constructor público sin parámetros que inicializa el atributo correo e a través del 
        /// InitializeComponent() inicializa los controles del formulario y ejecuta una nueva instancia
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();
            correo= new Correo();
        }
        /// <summary>
        /// Metodo que se ejecuta antes del cierre del formulario, cierra todos los hilos abiertos
        /// en la instacia correos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }
        /// <summary>
        /// Llena los ListBox del formulario con la información de los paquetes
        /// según su estado actual
        /// </summary>
        private void ActualizarEstados()
        {
            listBoxEntregado.Items.Clear();
            listBoxEnViaje.Items.Clear();
            listBoxIngresado.Items.Clear();
            if (!(correo.Paquete is null))
            {
                foreach (Paquete item in correo.Paquete)
                {
                    switch (item.Estado)
                    {
                        case Paquete.EEstado.Ingresado:
                            listBoxIngresado.Items.Add(item);
                            break;
                        case Paquete.EEstado.EnViaje:
                            listBoxEnViaje.Items.Add(item);
                            break;
                        case Paquete.EEstado.Entregado:
                            listBoxEntregado.Items.Add(item);
                            break;
                    }
                }
            }
        }
        /// <summary>
        /// Imprime informacion en un RichTextBox del parámetro genérico del Tipo de
        /// la Interface IMostrar T
        /// </summary>
        /// <typeparam name="T"></typeparam> Paquete o List Paquetes
        /// <param name="elemento"></param> lista de paquetes o paquetes
        private void MostrarInforamcion<T>(IMostrar<T> elemento)
        {
            try
            {
                if (!(elemento is null))
                {
                    this.richTextBoxMostrar.Text = elemento.MostrarDatos(elemento);
                    string auxPath = string.Format("{0}{1}", miPath, @"\salida.txt");
                    elemento.MostrarDatos(elemento).Guardar(auxPath);
                }
            }
            catch (ArchivosException ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(ex.Message);
                sb.AppendLine(ex.StackTrace);
                MessageBox.Show(sb.ToString(), "Error!");
            }
        }
        /// <summary>
        /// Metodo recursivo para poder actualizar datos en el formulario 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }
        /// <summary>
        /// Manejador del evento clik del boton Agregar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!(textBoxDireccion.Text=="") && !(mkTextBoxTrackingID.Text==""))
            {
                StringBuilder sb = new StringBuilder();
                Paquete nuevoPaquete = new Paquete(textBoxDireccion.Text,
                    mkTextBoxTrackingID.Text);
                nuevoPaquete.InformaEstado += this.paq_InformaEstado;

                try
                {
                    correo = correo + nuevoPaquete;
                }
                catch (TrackingIDRepetidoException)
                {
                    MessageBox.Show("Error al intentar cargar un Tracking Repetido");
                }
                ActualizarEstados();
            }
            else
            {
                MessageBox.Show("Faltan datos para agregar el paquete");
            }
            this.textBoxDireccion.Text = "";
            this.mkTextBoxTrackingID.Text = "";
            this.mkTextBoxTrackingID.Focus();
        }
        /// <summary>
        /// Manejador del evento Click de boton Mostrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            this.MostrarInforamcion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }
        /// <summary>
        /// Manejador del evento Click del boton Mostrar del ToolStripMenuItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.MostrarInforamcion<Paquete>((IMostrar<Paquete>)listBoxEntregado.SelectedItem);
        }
        private static string InnerString(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            if (!(ex.InnerException is null))
            {
                Exception e = ex.InnerException;
                do
                {
                    sb.AppendLine(e.Message);
                    e = e.InnerException;

                } while (!(e is null));
            }
            return sb.ToString();
        }
        private void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            StringBuilder sb = new StringBuilder();
            Exception ex = (Exception)args.ExceptionObject;
            sb.AppendLine(ex.Message);
            sb.AppendLine(InnerString(ex));
            sb.AppendLine(ex.StackTrace);
            MessageBox.Show(sb.ToString(), "Error!");
            correo.FinEntregas();
            this.Close();
        }

        private void FrmPpal_Load(object sender, EventArgs e)
        {
            currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);
        }
    }
}
