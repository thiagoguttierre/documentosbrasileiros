using DocumentosBrasileiros.Enums;
using DocumentosBrasileiros.Helpers;
using DocumentosBrasileiros.Interfaces;
using System;
using System.Linq;

namespace DocumentosBrasileiros.IE
{
    public class Pernambuco : IInscricaoEstadual
    {
        public UfEnum UfEnum => UfEnum.PE;

        private readonly int[] peso = { 5, 4, 3, 2, 1, 9, 8, 7, 6, 5, 4, 3, 2 };
        public bool Validar(string inscricaoEstadual)
        {
            if (inscricaoEstadual.Length != 9 && inscricaoEstadual.Length != 14) return false;

            string inscricaoSemDigito = inscricaoEstadual.Substring(0, inscricaoEstadual.Length - 2);
            return obterInscricaoComDigitos(inscricaoSemDigito) == inscricaoEstadual;
        }

        private string obterInscricaoComDigitos(string inscricaoSemDigito)
        {
            string d1 = "", d2 = "";

            string zeroEsquerda = string.Concat(Enumerable.Repeat("0", peso.Length - inscricaoSemDigito.Length));
            d1 = new DigitoVerificador().ObterDigitoMod11(zeroEsquerda + inscricaoSemDigito, peso).ToString();

            zeroEsquerda = string.Concat(Enumerable.Repeat("0", (peso.Length - 1) - inscricaoSemDigito.Length));
            d2 = new DigitoVerificador().ObterDigitoMod11(zeroEsquerda + inscricaoSemDigito + d1, peso).ToString();

            return inscricaoSemDigito + d1 + d2;
        }
        public string GerarFake()
        {
            string inscricaoSemDigito = "";

            Random rnd = new Random();

            int NoveOuQuatorze = rnd.NextDouble() > 0.5 ? 14 : 9;

            for (int i = 0; i < NoveOuQuatorze - 2; i++)
            {
                inscricaoSemDigito += rnd.Next(0, 9).ToString();
            }

            return obterInscricaoComDigitos(inscricaoSemDigito);
        }
    }
}
