using DocumentosBrasileiros.Enums;
using DocumentosBrasileiros.Helpers;
using DocumentosBrasileiros.Interfaces;
using System;

namespace DocumentosBrasileiros.IE
{
    public class MatoGrosso : IInscricaoEstadual
    {
        public UfEnum UfEnum => UfEnum.MT;

        private readonly int[] peso = { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        public bool Validar(string inscricaoEstadual)
        {
            if (inscricaoEstadual.Length != 11) return false;

            string inscricaoSemDigito = inscricaoEstadual.Substring(0, 10);

            return inscricaoEstadual ==
             inscricaoSemDigito + new DigitoVerificador().ObterDigitoMod11(inscricaoSemDigito, peso).ToString();
        }

        public string GerarFake()
        {
            string inscricaoSemDigito = "";
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                inscricaoSemDigito += rnd.Next(0, 9).ToString();
            }

            return inscricaoSemDigito + new DigitoVerificador().ObterDigitoMod11(inscricaoSemDigito, peso).ToString();
        }
    }
}
