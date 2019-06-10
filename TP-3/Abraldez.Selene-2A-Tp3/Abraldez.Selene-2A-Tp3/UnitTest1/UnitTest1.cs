using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesInstanciables;
using EntidadesAbstractas;

namespace UnitTest1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidarValorNumerico()
        {
            Profesor p1 = new Profesor(5, "Corde", "Jav", "96354423", Persona.ENacionalidad.Argentino);
            Assert.IsInstanceOfType(p1.DNI, typeof(int));
        }

        [TestMethod]
        public void ValidarDniInvalidoExcepcion()
        {
            try
            {
                Alumno a1 = new Alumno(5, "Wacha", "Zara", "zxcvvb", Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion);
                Assert.Fail("Deberia dar error en formato");
            }
            catch (DniInvalidoException e)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void ValidarNulidadenAtributos()
        {
            Universidad u1 = new Universidad();
            Alumno a1 = new Alumno(3, "Miler", "Pablo", "91111111", Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion);
            Profesor p1 = new Profesor(5, "Jacin", "Goma", "16353423", Persona.ENacionalidad.Argentino);

            Assert.IsNotNull(u1.Alumnos);
            Assert.IsNotNull(u1.Instructores);
            Assert.IsNotNull(u1.Jornadas);
            Assert.IsNotNull(a1);
            Assert.IsNotNull(p1);

        }

        [TestMethod]
        public void ValidarNacionalidadInvalidaExcepcion()
        {
            try
            {
                Alumno a1 = new Alumno(3, "Cambon", "Agus", "23456578", Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion);
                Assert.Fail("Deberia dar error de nacionalidad");

            }
            catch (NacionalidadInvalidaException e)
            {
                Assert.IsTrue(true);
            }

        }

        [TestMethod]
        public void ValidarSiSeRepiteAlumno()
        {
            Universidad u = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Perez", "12345678", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno a2 = new Alumno(1, "Juan", "Perez", "87654321", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            try
            {
                u += a1;
                u += a2;
                Assert.Fail("Deberia dar error ya que tienen el mismo legajo y son del mismo tipo");
            }
            catch (AlumnoRepetidoException e)
            {
                Assert.IsTrue(true);
            }
        }

    }
}
