using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UniTest1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        ///test que verifique que la lista de Paquetes del Correo esté instanciada
        public void TestListaDePaquetes()
        {
            Correo c1 = new Correo();
            Assert.AreNotEqual(c1.Paquetes, null);
        }

        [TestMethod]
        //test que verifique que no se puedan cargar dos Paquetes con el mismo Tracking ID.
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void TestPaquetesIguales()
        {
            Paquete p1 = new Paquete("Paquete1", "111-111-2222");
            Paquete p2 = new Paquete("Paquete2", "111-111-2222");

            Correo c1 = new Correo();

            try
            {
                c1 += p1;
                c1 += p2;
                Assert.Fail("Deberia lanzar excepcion por dos paquetes de igual ID");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
            }
        }
    }
}
