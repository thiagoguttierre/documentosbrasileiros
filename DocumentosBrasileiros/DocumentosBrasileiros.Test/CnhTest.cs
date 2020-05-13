using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocumentosBrasileiros.Test
{
    [TestClass]
    public class CnhTest
    {
        [TestMethod]
        public void CnhIsValid()
        {
           var doc = new Cnh("13975859080");
            Assert.IsTrue(doc.DocumentoValido());
        }

        [TestMethod]
        public void FakeCnhIsValid()
        {
            var doc = new Cnh();
            doc.GerarFake();
            Assert.IsTrue(doc.DocumentoValido());
        }
    }
}
