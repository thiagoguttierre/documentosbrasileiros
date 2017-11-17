using DocumentosBrasileiros.Enums;
using DocumentosBrasileiros.Helpers;
using System;

namespace DocumentosBrasileiros.Documentos.IE
{
    public class Rondonia :IDocumentoEstadual
    {
        public UF UF => UF.RO;

        private readonly int[] pesoIEAntiga = { 6, 5, 4, 3, 2 };
        private readonly int[] pesoIENova = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        public bool IsValid(string inscricaoEstadual)
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

        public string GenerateFake()
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
