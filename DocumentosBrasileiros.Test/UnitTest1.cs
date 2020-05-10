using DocumentosBrasileiros.Documentos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocumentosBrasileiros.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidacaoCnh()
        {
           var doc = new Documento("13975859080", TipoDocumento.Cnh);
            Assert.IsTrue(doc.DocumentoValido());
        }

        [TestMethod]
        public void GerarCnhValido()
        {
            var doc = new Documento(TipoDocumento.Cnh);
            doc.GerarDocumento();
            Assert.IsTrue(doc.DocumentoValido());
        }

        [TestMethod]
        public void ValidacaoIe_Sp()
        {
            var doc = new Documento("857.604.844.470", TipoDocumento.InscricaoEstadual, Enums.UfEnum.SP);
            Assert.IsTrue(doc.DocumentoValido());
        }


        [TestMethod]
        public void GerarIeSpValido()
        {
            var doc = new Documento(TipoDocumento.InscricaoEstadual, Enums.UfEnum.SP);
            doc.GerarDocumento();
            Assert.IsTrue(doc.DocumentoValido());
        }

    }
}
