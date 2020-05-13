using DocumentosBrasileiros.Documentos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocumentosBrasileiros.Test
{
    [TestClass]
    public class CnpjTest
    {
        [TestMethod]
        public void CnpjIsValid()
        {
           var doc = new Cnpj("06.990.590/0001-23");
            Assert.IsTrue(doc.DocumentoValido());
        }

        [TestMethod]
        public void FakeCnpjIsValid()
        {
            var doc = new Cnpj();
            doc.GerarFake();
            Assert.IsTrue(doc.DocumentoValido());
        }
    }
}
