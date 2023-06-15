using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocumentosBrasileiros.Test
{
    [TestClass]
    public class PisTest
    {
        [TestMethod]
        public void PisIsValid()
        {
            var doc = new Pis("657.59730.12-6");
            Assert.IsTrue(doc.DocumentoValido());
        }

        [TestMethod]
        public void FakePisIsValid()
        {
            var doc = new Pis();
            doc.GerarFake();
            Assert.IsTrue(doc.DocumentoValido());
        }
    }
}
