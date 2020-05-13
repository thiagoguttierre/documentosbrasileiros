using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocumentosBrasileiros.Test
{
    [TestClass]
    public class RenavamTest
    {
        [TestMethod]
        public void RenavamIsValid()
        {
            var docs = new List<string>
            {
                "83570974235",
                "93919221408",
                "75257898141"
            };

            foreach (var numero in docs)
            {
                var doc = new Renavam(numero);
                Assert.IsTrue(doc.DocumentoValido());
            }
        }

        [TestMethod]
        public void FakeRenavamIsValid()
        {
            var doc = new Renavam();
            doc.GerarFake();
            Assert.IsTrue(doc.DocumentoValido());
        }
    }
}
