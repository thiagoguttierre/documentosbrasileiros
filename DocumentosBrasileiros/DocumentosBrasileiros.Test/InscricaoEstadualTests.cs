using System;
using System.Collections.Generic;
using System.Linq;
using DocumentosBrasileiros.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocumentosBrasileiros.Test
{
    [TestClass]
    public class InscricaoEstadualTests
    {
        [TestMethod]
        public void FakesSaoValidos()
        {
            var ufs = Enum.GetValues(typeof(UfEnum)).Cast<UfEnum>();
            var errors = new List<string>();

            foreach (var uf in ufs)
            {
                for (int i = 0; i <= 10000; i++)
                {
                    var doc = new InscricaoEstadual(uf);
                    doc.GerarFake();

                    bool docValido = doc.DocumentoValido();

                    if (!docValido)
                    {
                        errors.Add($"{uf} falhou no teste de inscrição estadual com o número {doc.Numero}");
                    }
                }
            }



            Assert.IsTrue(!errors.Any(), string.Join(". ", errors));
        }


        [TestMethod]
        public void ValidacaoIe_Sp()
        {
            var doc = new InscricaoEstadual("857.604.844.470", UfEnum.SP);
            Assert.IsTrue(doc.DocumentoValido());
        }

        [TestMethod]
        public void ValidacaoIe_Ba()
        {
            var errors = new List<string>();

            new List<string>
            {
                "1 6 2 3 4 5 6 - 5 1",
                "123456748",
                "080917-69"
            }.ForEach(x => Assert.IsTrue(new InscricaoEstadual(x, UfEnum.BA).DocumentoValido()));

            for (int i = 0; i < 10; i++)
            {
                var doc = new InscricaoEstadual(UfEnum.BA);
                doc.GerarFake();
                var docValido = doc.DocumentoValido();

                if (!docValido)
                {
                    errors.Add($"falhou no teste de inscrição estadual com o número {doc.Numero}");
                }
            }

            Assert.IsTrue(!errors.Any(), string.Join(". ", errors));
        }

        [TestMethod]
        public void ValidacaoIe_Ap()
        {
            var errors = new List<string>();

            for (int i = 0; i <= 100000; i++)
            {
                var doc = new InscricaoEstadual(UfEnum.AP);
                doc.GerarFake();
                var docValido = doc.DocumentoValido();

                if (!docValido)
                {
                    errors.Add($"falhou no teste de inscrição estadual com o número {doc.Numero}");
                }
            }

            Assert.IsTrue(!errors.Any(), string.Join(". ", errors));
        }
    }
}