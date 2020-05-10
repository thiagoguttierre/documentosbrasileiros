using DocumentosBrasileiros.Enums;
using DocumentosBrasileiros.Helpers;
using System;

namespace DocumentosBrasileiros.Documentos.IE
{
    public class Maranhao : IDocumentoEstadual
    {
        public UfEnum UfEnum => UfEnum.MA;

        private readonly int[] peso = { 9, 8, 7, 6, 5, 4, 3, 2 };
        public bool Validar(string inscricaoEstadual)
        {
            if (inscricaoEstadual.Length != 9) return false;

            if (!inscricaoEstadual.StartsWith("12")) return false;

            string inscricaoSemDigito = inscricaoEstadual.Substring(0, 8);

            string digito1 = new DigitoVerificador().ObterDigitoMod11(inscricaoSemDigito, peso).ToString();

            return inscricaoSemDigito + digito1 == inscricaoEstadual;
        }

        public string GerarFake()
        {
            string inscricaoSemDigito = "12";
            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                inscricaoSemDigito += rnd.Next(0, 9).ToString();
            }

            return inscricaoSemDigito + new DigitoVerificador().ObterDigitoMod11(inscricaoSemDigito, peso).ToString();
        }

    }
}