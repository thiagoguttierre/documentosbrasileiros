using DocumentosBrasileiros.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentosBrasileiros.Documentos.IE
{
    public class Bahia : IDocumentoEstadual
    {
        public UfEnum UfEnum => UfEnum.BA;

        private readonly int[] peso = { 9, 8, 7, 6, 5, 4, 3, 2 };

        public bool Validar(string inscricaoEstadual)
        {
            int size = inscricaoEstadual.Length;
            if (size < 8 || size > 9) return false;

            string inscricaoSemDigito = inscricaoEstadual.Substring(0, size == 8 ? 6 : 7);
            int digito2 = ObterDigito(inscricaoSemDigito, inscricaoEstadual.Length);
            int digito1 = ObterDigito(inscricaoSemDigito + digito2.ToString(), inscricaoEstadual.Length);

            return inscricaoEstadual == inscricaoSemDigito + digito1.ToString() + digito2.ToString();
        }
        private int ObterDigito(string inscricaoSemDigito, int qtdeCaracteresTotal)
        {
            int modulo = 0;

            if (qtdeCaracteresTotal == 8)
            {
                modulo = (inscricaoSemDigito.StartsWith("6") || inscricaoSemDigito.StartsWith("7") || inscricaoSemDigito.StartsWith("9")) ? 11 : 10;
            }
            else
            {
                modulo = (new List<string>() { "6", "7", "9" }).Any(x => x == inscricaoSemDigito.Substring(1, 1)) ? 11 : 10;
            }


            while (inscricaoSemDigito.Length < peso.Length)
            {
                inscricaoSemDigito = "0" + inscricaoSemDigito;
            }

            int soma = 0;
            for (int i = 0; i < inscricaoSemDigito.Length; i++)
            {
                int _peso = peso[i];
                int _ie = int.Parse(inscricaoSemDigito[i].ToString());
                soma += int.Parse(inscricaoSemDigito[i].ToString()) * peso[i];
            }
            int resto = soma % modulo;
            if (modulo == 11 && resto < 2 || resto == 0)
                return 0;
            return modulo - resto;


        }

        public string GerarFake()
        {
            string inscricaoSemDigito = "";
            Random rnd = new Random();
            for (int i = 0; i < 7; i++)
            {
                inscricaoSemDigito += rnd.Next(0, 9).ToString();
            }
            int digito2 = ObterDigito(inscricaoSemDigito, 8);
            int digito1 = ObterDigito(inscricaoSemDigito + digito2.ToString(), 8);

            return inscricaoSemDigito + digito1.ToString() + digito2.ToString();
        }
    }
}
