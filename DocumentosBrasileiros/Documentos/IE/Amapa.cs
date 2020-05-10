using DocumentosBrasileiros.Enums;
using System;

namespace DocumentosBrasileiros.Documentos.IE
{
    /// <summary>
    /// CCNNNNNND
    /// C(2)- Constante 03
    /// N(6) - Empresa
    /// D(1)-Dígito
    /// Fonte: http://www.sintegra.gov.br/Cad_Estados/cad_AP.html
    /// </summary>
    /// 
    public class Amapa : IDocumentoEstadual
    {
        public UfEnum UfEnum => UfEnum.AP;
        private readonly int[] peso = { 9, 8, 7, 6, 5, 4, 3, 2 };

        public bool Validar(string inscricaoEstadual)
        {
            if (inscricaoEstadual.Length != 9) return false;
            if (!inscricaoEstadual.StartsWith("03")) return false;

            string inscricaoSemDigito = inscricaoEstadual.Substring(0, 8);

            return inscricaoSemDigito + ObterDigito(inscricaoSemDigito).ToString() == inscricaoEstadual;
        }

        private int ObterDigito(string inscricaoSemDigito)
        {
            int p = 0;
            int d = 0;

            int inscricaoSemDigitoInt = int.Parse(inscricaoSemDigito);
            if (inscricaoSemDigitoInt < 03017001)
            {
                p = 5;
            }
            else if (inscricaoSemDigitoInt >= 03017001 && inscricaoSemDigitoInt < 03019023)
            {
                p = 9;
                d = 1;
            }


            int soma = p;
            for (int i = 0; i < peso.Length; ++i)
                soma += peso[i] * Convert.ToInt32(inscricaoSemDigito[i].ToString());

            int digito = 11 - soma % 11;

            if (digito == 10) digito = 0;
            else if (digito == 1) digito = d;


            return digito;
        }

        public string GerarFake()
        {
            string inscricaoSemDigito = "03";
            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                inscricaoSemDigito += rnd.Next(0, 9).ToString();
            }
            return inscricaoSemDigito + ObterDigito(inscricaoSemDigito).ToString();

        }
    }
}
