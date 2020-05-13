using System;
using DocumentosBrasileiros.Enums;
using DocumentosBrasileiros.Interfaces;

namespace DocumentosBrasileiros.IE
{
    public class Amazonas : IInscricaoEstadual
    {
        public UfEnum UfEnum => UfEnum.AM;

        private readonly int[] peso = { 9, 8, 7, 6, 5, 4, 3, 2 };
        public bool Validar(string inscricaoEstadual)
        {
            if (inscricaoEstadual.Length != 9) return false;

            string inscricaoSemDigito = inscricaoEstadual.Substring(0, 8);

            return inscricaoSemDigito + ObterDigito(inscricaoSemDigito).ToString() == inscricaoEstadual;
        }

        private int ObterDigito(string inscricaoSemDigito)
        {
            int soma = 0;
            for (int i = 0; i < peso.Length; ++i)
                soma += peso[i] * int.Parse(inscricaoSemDigito[i].ToString());

            int digito;
            if (soma < 11)
            {
                digito = 11 - soma;
            }
            else
            {
                int resto = soma % 11;
                digito = resto >= 2 ? 11 - resto : 0;
            }
            return digito;
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
