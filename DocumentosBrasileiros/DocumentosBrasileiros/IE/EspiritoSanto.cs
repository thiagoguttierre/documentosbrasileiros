using System;
using DocumentosBrasileiros.Enums;
using DocumentosBrasileiros.Interfaces;

namespace DocumentosBrasileiros.IE
{
    public class EspiritoSanto : IInscricaoEstadual
    {
        public UfEnum UfEnum => UfEnum.ES;

        private readonly int[] peso = { 9, 8, 7, 6, 5, 4, 3, 2 };
        public bool Validar(string inscricaoEstadual)
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

        public string GerarFake()
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
