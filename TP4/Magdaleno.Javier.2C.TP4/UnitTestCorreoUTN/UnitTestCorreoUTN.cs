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
        public void TestInstanciaListaPaquete()
        {
            // arrange
            Correo miCorreo;

            // act
            miCorreo = new Correo();


            //Asert
            Assert.IsNotNull(miCorreo.Paquete);

        }
        [TestMethod]
        [ExpectedException(typeof(TrackingIDRepetidoException))]
        public void TestPaqueteRepetido()
        {
            // Arrange
            Correo miCorreo;
            Paquete paquete1;
            Paquete paquete2;

            // Act
            miCorreo = new Correo();
            paquete1 = new Paquete("","1");
            paquete2 = new Paquete("Otra Direccion", "1");

            miCorreo = miCorreo + paquete1;
            miCorreo = miCorreo + paquete2;

            // Assert
            
        }
    }
}
