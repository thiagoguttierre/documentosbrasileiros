using DocumentosBrasileiros.Enums;
using DocumentosBrasileiros.Helpers;
using System;
using DocumentosBrasileiros.Interfaces;

namespace DocumentosBrasileiros.Documentos.IE
{
    public class RioGrandeDoNorte : IInscricaoEstadual
    {
        public UfEnum UfEnum => UfEnum.RN;

        private readonly int[] peso = { 0, 9, 8, 7, 6, 5, 4, 3, 2 };
        public bool Validar(string inscricaoEstadual)
        {
            if (inscricaoEstadual.Length < 9 || inscricaoEstadual.Length > 10) return false;
            if (!inscricaoEstadual.StartsWith("20")) return false;

            string inscricaoSemDigito = inscricaoEstadual.Substring(0, inscricaoEstadual.Length - 1);
            string digito = new DigitoVerificador().ObterDigitoMod11((inscricaoEstadual.Length == 9 ? "0" : "") + inscricaoSemDigito, peso).ToString();

            return
                inscricaoEstadual ==
                inscricaoSemDigito + digito;

        }

        public string GerarFake()
        {
            string inscricaoSemDigito = "20";
            Random rnd = new Random();
            int qtdeCaracteres = rnd.NextDouble() > 0.5 ? 9 : 10;

            for (int i = 0; i < qtdeCaracteres - 3; i++)
            {
                inscricaoSemDigito += rnd.Next(0, 9).ToString();
            }
            string digito = new DigitoVerificador().ObterDigitoMod11((qtdeCaracteres == 9 ? "0" : "") + inscricaoSemDigito, peso).ToString();
            return inscricaoSemDigito + digito;
        }
    }
}
