using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesInstanciables;
using EntidadesAbstractas;
using Archivos;

namespace UnitTest1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidarDniInvalidoExcepcion()
        {
            try
            {
                Alumno a1 = new Alumno(5, "Wacha", "Zara", "zxcvvb", Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion);
                Assert.Fail("Deberia dar error en formato");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

        [TestMethod]
        public void ValidarNacionalidadInvalidaExcepcion()
        {
            try
            {
                Alumno a1 = new Alumno(3, "Cambon", "Agus", "12345678", Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion);
                Assert.Fail("Deberia dar error de nacionalidad");
            }
            catch (Exception e)
            {
            }
        }



        [TestMethod]
        public void ValidarNotNull()
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
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }

        [TestMethod]
        public void ExcepcionesGuardar()
        {
            try
            {
                Xml<int> xml = new Xml<int>();
                xml.Guardar(null, 999);
                Assert.Fail("Deberia haber lanzado excepccion por daro nulo");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArchivosException));
            }
        }
    }
}
