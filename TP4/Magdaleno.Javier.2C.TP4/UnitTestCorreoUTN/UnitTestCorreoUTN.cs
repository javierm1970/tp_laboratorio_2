using System;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;

namespace UnitTestCorreoUTN
{
    [TestClass]
    public class UnitTestCorreoUTN
    {
        [TestMethod]
        // test que verifica que la lista de Paquetes del Correo esté instanciada
        public void TestInstanciaListaPaquete()
        {
            // arrange
            // Declara un variable del Tipo Correo
            Correo miCorreo;

            // act
            // Instancia la variable de Tipo Correo
            miCorreo = new Correo();


            //Asert
            // Certifica que la lista de paquetes del Objeto Correo no es Null
            Assert.IsNotNull(miCorreo.Paquete);

        }
        [TestMethod]
        // etiqueta que representa el tipo de Exception que se tiene que producir 
        // para que el test sea correcto. 
        [ExpectedException(typeof(TrackingIDRepetidoException))]
        
        //test que verifica que no se puedan cargar dos Paquetes con el mismo Tracking ID.
        public void TestPaqueteRepetido()
        {
            // Arrange
            // Declara una valibles del Tipo Correo y dos variables del tipo Paquete
            Correo miCorreo;
            Paquete paquete1;
            Paquete paquete2;

            // Act
            // Instancia al objeto miCorreo, instancia dos objetos del Tipo Paquete con el mismo
            // trackingID
            miCorreo = new Correo();
            paquete1 = new Paquete("","1");
            paquete2 = new Paquete("Otra Direccion", "1");

            // Intenta agregarlos a la lista Correo mediante la sobrecarga del operator +
            // para provocar le lanzamiento de la Exception: TrackingIDRepetidoException
            miCorreo = miCorreo + paquete1;
            miCorreo = miCorreo + paquete2;

            // Assert
            
        }
    }
}
