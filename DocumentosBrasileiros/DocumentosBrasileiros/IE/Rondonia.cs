using System;
using DocumentosBrasileiros.Enums;
using DocumentosBrasileiros.Helpers;
using DocumentosBrasileiros.Interfaces;

namespace DocumentosBrasileiros.IE
{
    public class Rondonia :IInscricaoEstadual
    {
        public UfEnum UfEnum => UfEnum.RO;

        private readonly int[] pesoIEAntiga = { 6, 5, 4, 3, 2 };
        private readonly int[] pesoIENova = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        public bool Validar(string inscricaoEstadual)
        {
            if (inscricaoEstadual.Length != 9 && inscricaoEstadual.Length != 14) return false;


            string digito = "";
            if (inscricaoEstadual.Length == 9)
            {
                digito = new DigitoVerificador().ObterDigitoMod11(inscricaoEstadual.Substring(3, 5), pesoIEAntiga).ToString();
            }
            else
            {
                digito = new DigitoVerificador().ObterDigitoMod11(inscricaoEstadual.Substring(0, 13), pesoIENova).ToString();
            }

            return inscricaoEstadual.EndsWith(digito);
               
        }

        public string GerarFake()
        {
            string inscricaoSemDigito = "";
            Random rnd = new Random();
            for (int i = 0; i < 13; i++)
            {
                inscricaoSemDigito += rnd.Next(0, 9).ToString();
            }

            return inscricaoSemDigito + new DigitoVerificador().ObterDigitoMod11(inscricaoSemDigito, pesoIENova);
        }

    }
}
