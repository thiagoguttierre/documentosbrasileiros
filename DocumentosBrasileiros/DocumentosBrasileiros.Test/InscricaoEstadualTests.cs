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
                var doc = new InscricaoEstadual(uf);
                doc.GerarFake();

                bool docValido = doc.DocumentoValido();

                if (!docValido)
                {
                    errors.Add($"{uf} falhou no teste de inscrição estadual com o número {doc.Numero}");
                }
            }

            

            Assert.IsTrue(!errors.Any(), string.Join(". ",errors));
        }


        [TestMethod]
        public void ValidacaoIe_Sp()
        {
            var doc = new InscricaoEstadual("857.604.844.470", Enums.UfEnum.SP);
            Assert.IsTrue(doc.DocumentoValido());
        }
    }
}