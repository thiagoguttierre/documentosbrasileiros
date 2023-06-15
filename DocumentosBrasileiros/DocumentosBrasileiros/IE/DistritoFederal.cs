using DocumentosBrasileiros.Enums;
using DocumentosBrasileiros.Interfaces;
using System;

namespace DocumentosBrasileiros.IE
{
    public class DistritoFederal : IInscricaoEstadual
    {
        public UfEnum UfEnum => UfEnum.DF;

        private readonly int[] peso = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        public bool Validar(string inscricaoEstadual)
        {
            if (inscricaoEstadual.Length != 13)
                return false;

            if (!inscricaoEstadual.StartsWith("07") && !inscricaoEstadual.StartsWith("08"))
                return false;

            string inscricaoSemDigito = inscricaoEstadual.Substring(0, 11);
            string digito1 = ObterDigito("0" + inscricaoSemDigito).ToString();
            string digito2 = ObterDigito(inscricaoSemDigito + digito1).ToString();

            return inscricaoSemDigito + digito1 + digito2 == inscricaoEstadual;
        }

        private int ObterDigito(string valor)
        {
            int soma = 0;
            for (int i = 0; i < peso.Length; ++i)
                soma += peso[i] * int.Parse(valor[i].ToString());

            int digito = 11 - soma % 11;
            if (digito > 9)
                digito = 0;
            return digito;
        }

        public string GerarFake()
        {
            string inscricaoSemDigito = "07";
            Random rnd = new Random();
            for (int i = 0; i < 9; i++)
            {
                inscricaoSemDigito += rnd.Next(0, 9).ToString();
            }

            string d1 = ObterDigito("0" + inscricaoSemDigito).ToString();
            string d2 = ObterDigito(inscricaoSemDigito + d1).ToString();
            return inscricaoSemDigito + d1 + d2;
        }
    }
}
