using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesAbstractas;
using EntidadesInstanciables;

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
            
            //a1 valores por defecto legajo=0, dni=1 
            Alumno a1 = new Alumno();
            //a2 valores por defecto legajo=0, dni=1
            Alumno a2 = new Alumno();

            // act

            uni += a1;
            uni += a2;

            // assert
        }
        /// <summary>
        /// Testea que se lance la Excepcion DniInvalidoException cuando se intenta
        /// crear el objeto del Tipo Profesor p3 con un dni inválido
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
            
            //dni válido
            p1 = new Profesor(0,"","","38000001",Persona.ENacionalidad.Argentino);
            //dni válido
            p2 = new Profesor(0,"","","38001",Persona.ENacionalidad.Argentino);
            //dni inválido tamaño incorrecto
            p3 = new Profesor(0,"","","38000000000001",Persona.ENacionalidad.Argentino);

            // assert
        }
        /// <summary>
        /// Testea que cuando se crea una Universidad la lista Alumnos 
        /// se inicialice, y que no sea null
        /// </summary>
        [TestMethod]
        public void TestInicializarAlumnos()
        {
            // arrange

            Universidad uni;

            // act

            uni = new Universidad();

            // assert
            Assert.IsNotNull(uni.Alumnos);
        }
        /// <summary>
        /// Testea que cuando se suma una clase a la universidad, si no hay profesor en la lista 
        /// se lanzará una Exception SinProfesorException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void TestInicializarJornada()
        {
            // arrange 
            Universidad uni2;
            Alumno a1;

            // act

            uni2 = new Universidad();
            a1 = new Alumno();
            uni2 += a1;
            uni2 += Universidad.EClases.Laboratorio;

            // assert

        }
    }
}
