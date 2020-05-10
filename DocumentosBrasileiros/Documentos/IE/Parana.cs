using DocumentosBrasileiros.Enums;
using DocumentosBrasileiros.Helpers;
using System;

namespace DocumentosBrasileiros.Documentos.IE
{
    public class Parana : IDocumentoEstadual
    {
        public UfEnum UfEnum => UfEnum.PR;

        private readonly int[] peso = { 4, 3, 2, 7, 6, 5, 4, 3, 2 };
        public bool Validar(string inscricaoEstadual)
        {
            if (inscricaoEstadual.Length != 10) return false;

            string inscricaoSemDigito = inscricaoEstadual.Substring(0, 8);
            string digito1 = new DigitoVerificador().ObterDigitoMod11("0" + inscricaoSemDigito, peso).ToString();
            string digito2 = new DigitoVerificador().ObterDigitoMod11(inscricaoSemDigito + digito1, peso).ToString();

            return inscricaoEstadual == inscricaoSemDigito + digito1 + digito2;
        }

        public string GerarFake()
        {
            string inscricaoSemDigito = "";
            Random rnd = new Random();
            for (int i = 0; i < 8; i++)
            {
                inscricaoSemDigito += rnd.Next(0, 9).ToString();
            }
            string digito1 = new DigitoVerificador().ObterDigitoMod11("0" + inscricaoSemDigito, peso).ToString();
            string digito2 = new DigitoVerificador().ObterDigitoMod11(inscricaoSemDigito + digito1, peso).ToString();

            return inscricaoSemDigito + digito1 + digito2;
        }
    }
}
