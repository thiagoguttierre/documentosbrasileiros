using DocumentosBrasileiros.Enums;
using System;

namespace DocumentosBrasileiros.Documentos.IE
{
    public class EspiritoSanto : IDocumentoEstadual
    {
        public UF UF => UF.ES;

        private readonly int[] peso = { 9, 8, 7, 6, 5, 4, 3, 2 };
        public bool IsValid(string inscricaoEstadual)
        {
            if (inscricaoEstadual.Length != 9) return false;

            string inscricaoSemDigito = inscricaoEstadual.Substring(0, 8);

            string digito = ObterDigito(inscricaoSemDigito).ToString();

            return inscricaoSemDigito + digito == inscricaoEstadual;
        }

        private int ObterDigito(string inscricaoSemDigito)
        {
            int soma = 0;
            for (int i = 0; i < peso.Length; ++i)
                soma += peso[i] * int.Parse(inscricaoSemDigito[i].ToString());

            int digito = soma % 11;

            return digito >= 2 ? 11 - digito : 0;
        }

        public string GenerateFake()
        {
            string inscricaoSemDigito = "";
            Random rnd = new Random();
            for (int i = 0; i < 8; i++)
            {
                inscricaoSemDigito += rnd.Next(0, 9).ToString();
            }

            return inscricaoSemDigito + ObterDigito(inscricaoSemDigito).ToString();
        }
    }
}
