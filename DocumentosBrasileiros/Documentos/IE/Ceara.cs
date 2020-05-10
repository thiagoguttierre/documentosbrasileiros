using DocumentosBrasileiros.Enums;
using System;

namespace DocumentosBrasileiros.Documentos.IE
{
    public class Ceara : IDocumentoEstadual
    {
        public UfEnum UfEnum => UfEnum.CE;

        private readonly int[] peso = { 9, 8, 7, 6, 5, 4, 3, 2 };

        public bool Validar(string inscricao)
        {
            if (inscricao.Length != 9) return false;

            string inscricaoSemDigito = inscricao.Substring(0, 8);

            int digito = ObterDigito(inscricaoSemDigito);
            return inscricao == inscricaoSemDigito + digito.ToString();
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
            string inscricaoSemDigito = "";
            Random rnd = new Random();
            for (int i = 0; i < 8; i++)
            {
                inscricaoSemDigito += rnd.Next(0, 9).ToString();
            }
            int digito = ObterDigito(inscricaoSemDigito);

            return inscricaoSemDigito + digito.ToString();
        }
    }
}
