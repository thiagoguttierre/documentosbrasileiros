using System;
using System.Collections.Generic;
using System.Linq;
using DocumentosBrasileiros.Enums;
using DocumentosBrasileiros.Helpers;
using DocumentosBrasileiros.Interfaces;

namespace DocumentosBrasileiros.IE
{
    public class Bahia : IInscricaoEstadual
    {
        public UfEnum UfEnum => UfEnum.BA;

        private readonly int[] _pesoDigito2 = { 8, 7, 6, 5, 4, 3, 2 };
        private readonly int[] _pesoDigito1 = { 9, 8, 7, 6, 5, 4, 3, 2 };

        public bool Validar(string inscricaoEstadual)
        {
            int size = inscricaoEstadual.Length;
            if (size < 8 || size > 9)
            {
                return false;
            }

            inscricaoEstadual = inscricaoEstadual.Length == 8
                ? inscricaoEstadual.PadLeft(9, '0')
                : inscricaoEstadual;

            var inscricaoSemDigito = inscricaoEstadual.Substring(0, 7);

            var digitos = ObterDigitos(inscricaoSemDigito);

            return inscricaoEstadual == $"{inscricaoSemDigito}{digitos}";
        }
        private string ObterDigitos(string inscricaoSemDigito)
        {
            string segundoDigito = inscricaoSemDigito.Substring(1, 1);

            int mod =
                new List<string> { "0", "1", "2", "3", "4", "5", "8" }.Contains(segundoDigito)
                    ? 10
                    : 11;

            return mod == 10
                ? ObterDigitosMod10(inscricaoSemDigito)
                : ObterDigitosMod11(inscricaoSemDigito);
        }
        private string ObterDigitosMod10(string inscricaoSemDigito)
        {
            int mod = 10;

            inscricaoSemDigito = inscricaoSemDigito.PadLeft(_pesoDigito2.Length, '0');

            var resto = new DigitoVerificador().ObterMod(inscricaoSemDigito, _pesoDigito2, mod);
            int digito2 = resto == 0
                ? 0
                : mod - resto;

            var resto2 = new DigitoVerificador().ObterMod($"{inscricaoSemDigito + digito2}", _pesoDigito1, mod);

            int digito1 = resto2 == 0
                ? 0
                : mod - resto2;

            return $"{digito1}{digito2}";
        }
        private string ObterDigitosMod11(string inscricaoSemDigito)
        {
            int mod = 11;

            inscricaoSemDigito = inscricaoSemDigito.PadLeft(_pesoDigito2.Length, '0');

            var resto = new DigitoVerificador().ObterMod(inscricaoSemDigito, _pesoDigito2, mod);
            int digito2 = resto == 0 || resto == 1
                ? 0
                : mod - resto;

            var resto2 = new DigitoVerificador().ObterMod($"{inscricaoSemDigito + digito2}", _pesoDigito1, mod);

            int digito1 = resto2 == 0 || resto2 == 1
                ? 0
                : mod - resto2;

            return $"{digito1}{digito2}";
        }

        public string GerarFake()
        {
            var inscricaoSemDigito = "";
            var rnd = new Random();
            for (int i = 0; i < 7; i++)
            {
                inscricaoSemDigito += rnd.Next(0, 9).ToString();
            }
            var digitos = ObterDigitos(inscricaoSemDigito);

            return $"{inscricaoSemDigito}{digitos}";
        }
    }
}
