using DocumentosBrasileiros.Enums;
using DocumentosBrasileiros.Helpers;
using System;

namespace DocumentosBrasileiros.Documentos.IE
{
    public class Sergipe : IDocumentoEstadual
    {
        public UF UF => UF.SE;

        private readonly int[] peso = { 9, 8, 7, 6, 5, 4, 3, 2 };
        public bool IsValid(string inscricaoEstadual)
        {
            if (inscricaoEstadual.Length != 9) return false;
            string inscricaoSemDigito = inscricaoEstadual.Substring(0, 8);

            return inscricaoEstadual ==
                inscricaoSemDigito + new DigitoVerificador().ObterDigitoMod11(inscricaoSemDigito, peso).ToString();
        }

        public string GenerateFake()
        {
            string inscricaoSemDigito = "";
            Random rnd = new Random();
            for (int i = 0; i < 8; i++)
            {
                inscricaoSemDigito += rnd.Next(0, 9).ToString();
            }

            return inscricaoSemDigito + new DigitoVerificador().ObterDigitoMod11(inscricaoSemDigito, peso);
        }
    }
}
