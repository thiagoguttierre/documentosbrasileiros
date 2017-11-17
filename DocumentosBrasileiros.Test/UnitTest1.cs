using DocumentosBrasileiros.Documentos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocumentosBrasileiros.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidacaoCNH()
        {
           var doc = new Documento("13975859080", TipoDocumento.CNH);
            Assert.IsTrue(doc.DocumentoValido());
        }

        [TestMethod]
        public void GerarCNHValido()
        {
            var doc = new Documento(TipoDocumento.CNH);
            doc.GerarDocumento();
            Assert.IsTrue(doc.DocumentoValido());
        }

        [TestMethod]
        public void ValidacaoIE_SP()
        {
            var doc = new Documento("857.604.844.470", TipoDocumento.InscricaoEstadual, Enums.UF.SP);
            Assert.IsTrue(doc.DocumentoValido());
        }


        [TestMethod]
        public void GerarIeSpValido()
        {
            var doc = new Documento(TipoDocumento.InscricaoEstadual, Enums.UF.SP);
            doc.GerarDocumento();
            Assert.IsTrue(doc.DocumentoValido());
        }

    }
}
