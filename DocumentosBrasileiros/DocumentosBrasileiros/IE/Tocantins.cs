using System;
using System.Collections.Generic;
using DocumentosBrasileiros.Enums;
using DocumentosBrasileiros.Helpers;
using DocumentosBrasileiros.Interfaces;

namespace DocumentosBrasileiros.IE
{
    /// <summary>
    /// Fonte: http://www2.sefaz.to.gov.br/Servicos/Sintegra/calinse.htm
    /// NNTTNNNNNND
    /// N(*2)T(*2)(N*6)(D)
    /// Valores possíveis de T:01 - Produtor Rural. 02 - Industria e Comércio. 03 - Empresas Rudimentares. 99 = Empresas do Cadastro Antigo (SUSPENSAS)
    /// </summary>
    public class Tocantins : IInscricaoEstadual
    {
        public UfEnum UfEnum => UfEnum.TO;

        private readonly int[] peso = { 9, 8, 7, 6, 5, 4, 3, 2 };
        private readonly IList<string> T = new List<string> {
            "01" /*Produto Rural*/ ,
            "02" /*Industria e Comercio*/,
            "03" /*Empresas Rudimentares*/,
            "99" /*Empresas de Cadastro Antigo (SUSPENSAS)*/ };
        public bool Validar(string inscricaoEstadual)
        {
            if (inscricaoEstadual.Length == 11)
            {
                return IsValid11Chars(inscricaoEstadual);
            }
            else if (inscricaoEstadual.Length == 9)
            {
                return IsValid9Chars(inscricaoEstadual);
            }


            return false;
        }
        private bool IsValid11Chars(string inscricaoEstadual)
        {
            if (!T.Contains(inscricaoEstadual.Substring(2, 2))) return false;

            string inscricaoSemDigitoSemT = inscricaoEstadual.Substring(0, 2) + inscricaoEstadual.Substring(4, 6);

            string digito = new DigitoVerificador().ObterDigitoMod11(inscricaoSemDigitoSemT, peso).ToString();

            return inscricaoEstadual.EndsWith(digito);
        }
        private bool IsValid9Chars(string inscricaoEstadual)
        {

            string inscricaoSemDigito = inscricaoEstadual.Substring(0, 8);

            string digito = new DigitoVerificador().ObterDigitoMod11(inscricaoSemDigito, peso).ToString();

            return inscricaoEstadual.EndsWith(digito);
        }

        public string GerarFake()
        {
            string inscricaoSemDigitoSemT = "";
            Random rnd = new Random();
            for (int i = 0; i < 8; i++)
            {
                inscricaoSemDigitoSemT += rnd.Next(0, 9).ToString();
            }
            double _random = rnd.NextDouble();

            string digito = new DigitoVerificador().ObterDigitoMod11(inscricaoSemDigitoSemT, peso).ToString();

            string t = "";
            if (_random < 0.33) t = T[0];
            else if (_random >= 0.33 && _random < 0.66) t = T[1];
            else t = T[2];

            return inscricaoSemDigitoSemT.Substring(0, 2) + t + inscricaoSemDigitoSemT.Substring(2, 6) + digito;

            //return inscricaoSemDigitoSemT + new ValidadorDigito().ObterDigitoMod11(inscricaoSemDigitoSemT, peso);
        }
    }
}
