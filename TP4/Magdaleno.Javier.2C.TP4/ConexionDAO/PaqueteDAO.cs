using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Excepciones;


namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        static PaqueteDAO()
        {
            conexion = new SqlConnection();
            comando = new SqlCommand();
            string stringConection = "Data Source = localhost; DataBase = ClinicaUTN; Trusted_Connection=True;";
            conexion.ConnectionString = stringConection;
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
        }
        /// <summary>
        /// Metodo que realiza un INSERT en la tabla Paquetes
        /// </summary>
        /// <param name="turno"></param> objeto Tipo Turno
        /// <returns> true si pudo ser agregado a la BD, de lo contrario se lanzara una excepcion </returns>

        public static bool Insertar(Paquete p)
        {
            bool retorno = false;
            try
            {
                comando.Parameters.Clear();
                comando.Parameters.Add(new SqlParameter("DirEntrega", p.DireccionEntrega));
                comando.Parameters.Add(new SqlParameter("IDTracking", p.TrackingID));
                comando.Parameters.Add(new SqlParameter("Alumno", "Magdaleno Javier Alejandro - 2ºC"));

                comando.CommandText = @"INSERT INTO dbo.Paquetes" +
                                         "        (direccionEntrega, trackingID, alumno)" +
                                         " VALUES (@DirEntrega, @IDTracking, @Alumno)";
                conexion.Open();
                comando.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception ex)
            {
                throw new SqlReadOrWriteException(ex);
            }
            finally
            {
                conexion.Close();
            }
            return retorno;
        }
    }
}
