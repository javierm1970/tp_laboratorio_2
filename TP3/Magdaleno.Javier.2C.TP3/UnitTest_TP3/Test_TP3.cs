﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesAbstractas;
using Magdaleno.Javier._2C.TP3;

namespace UnitTest_TP3
{
    [TestClass]
    public class Test_TP3
    {
        /// <summary>
        /// Testea que se lance la Excepcion AlumnoRepetidoException cuando se intenta
        /// incorporar a la lista de Alumnos de la Universidad dos Alumnos con el mismo
        /// legajo y el mismo Dni
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestAlumRepetido()
        {
            // arrange
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno();
            Alumno a2 = new Alumno();

            // act

            uni += a1;
            uni += a2;

            // assert
        }
        /// <summary>
        /// Testea que se lance la Excepcion DniInvalidoException cuando se intenta
        /// crear el objeto del Tipo Profesro p3 con un dni inválido
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDNIInvalido()
        {
            // arrange

            Profesor p1;
            Profesor p2;
            Profesor p3;

            // act

            p1 = new Profesor(0,"","","38000001",Persona.ENacionalidad.Argentino);
            p2 = new Profesor(0,"","","38001",Persona.ENacionalidad.Argentino);
            p3 = new Profesor(0,"","","38000000000001",Persona.ENacionalidad.Argentino);

            // assert
        }
        /// <summary>
        /// Testea que se cuando se crea una Universidad la lista Alumnos 
        /// se instancie, que no sea null
        /// </summary>
        [TestMethod]
        public void TestInstanciarAtributo()
        {
            // arrange

            Universidad uni;;

            // act

            uni = new Universidad();

            // assert
            Assert.IsNotNull(uni.Alumnos);
        }
    }
}
