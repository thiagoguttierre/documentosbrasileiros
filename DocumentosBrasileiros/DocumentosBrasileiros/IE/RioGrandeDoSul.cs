using DocumentosBrasileiros.Enums;
using DocumentosBrasileiros.Helpers;
using DocumentosBrasileiros.Interfaces;
using System;

namespace DocumentosBrasileiros.IE
{
    public class RioGrandeDoSul : IInscricaoEstadual
    {
        public UfEnum UfEnum => UfEnum.RS;

        private readonly int[] peso = { 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        public bool Validar(string inscricaoEstadual)
        {
            if (inscricaoEstadual.Length != 10) return false;
            string inscricaoSemDigito = inscricaoEstadual.Substring(0, 9);
            return inscricaoEstadual ==
                inscricaoSemDigito + new DigitoVerificador().ObterDigitoMod11(inscricaoSemDigito, peso).ToString();
        }
        public string GerarFake()
        {
            string inscricaoSemDigito = "";
            Random rnd = new Random();
            for (int i = 0; i < 9; i++)
            {
                inscricaoSemDigito += rnd.Next(0, 9).ToString();
            }

            return inscricaoSemDigito + new DigitoVerificador().ObterDigitoMod11(inscricaoSemDigito, peso);
        }
    }
}
