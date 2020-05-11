using DocumentosBrasileiros.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using DocumentosBrasileiros.Interfaces;

namespace DocumentosBrasileiros.Documentos.IE
{
    public class Bahia : IInscricaoEstadual
    {
        public UfEnum UfEnum => UfEnum.BA;

        private readonly int[] _peso = { 9, 8, 7, 6, 5, 4, 3, 2 };

        public bool Validar(string inscricaoEstadual)
        {
            int size = inscricaoEstadual.Length;
            if (size < 8 || size > 9) return false;

            string inscricaoSemDigito = inscricaoEstadual.Substring(0, size == 8 ? 6 : 7);
            int digito2 = ObterDigito(inscricaoSemDigito, inscricaoEstadual.Length);
            int digito1 = ObterDigito(inscricaoSemDigito + digito2.ToString(), inscricaoEstadual.Length);

            return inscricaoEstadual == $"{inscricaoSemDigito}{digito1}{digito2}";
        }
        private int ObterDigito(string inscricaoSemDigito, int qtdeCaracteresTotal)
        {
            int modulo;

            if (qtdeCaracteresTotal == 8)
            {
                modulo = (inscricaoSemDigito.StartsWith("6") || inscricaoSemDigito.StartsWith("7") || inscricaoSemDigito.StartsWith("9")) ? 11 : 10;
            }
            else
            {
                modulo = new List<string> { "6", "7", "9" }.Any(x => x == inscricaoSemDigito.Substring(1, 1)) ? 11 : 10;
            }

            inscricaoSemDigito = inscricaoSemDigito.PadLeft(_peso.Length, '0');

            var soma = 0;
            for (var i = 0; i < inscricaoSemDigito.Length; i++)
            {
                soma += int.Parse(inscricaoSemDigito[i].ToString()) * _peso[i];
            }

            var resto = soma % modulo;

            return modulo == 11 && resto < 2 || resto == 0
                ? 0
                : modulo - resto;
        }

        public string GerarFake()
        {
            var inscricaoSemDigito = "";
            var rnd = new Random();
            for (int i = 0; i < 7; i++)
            {
                inscricaoSemDigito += rnd.Next(0, 9).ToString();
            }
            var digito2 = ObterDigito(inscricaoSemDigito, 8);
            var digito1 = ObterDigito($"{inscricaoSemDigito}{digito2}", 8);

            return $"{inscricaoSemDigito}{digito1}{digito2}";
        }
    }
}
