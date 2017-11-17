using DocumentosBrasileiros.Enums;
using DocumentosBrasileiros.Helpers;
using System;
using System.Linq;

namespace DocumentosBrasileiros.Documentos.IE
{
    /// <summary>
    /// 24XNNNNND
    /// 24- Código Estado
    /// X - Tipo de Empresa: 0-Normal, 3-Produtor Rural, 5-Substituta, 7- Micro-Empresa Ambulante, 8-Micro-Empresa, 4, 2 e 1 Não são oficiais
    /// NNNNN - Número da empresa
    /// D - Dígito verificador
    /// </summary>
    public class Alagoas: IDocumentoEstadual
    {
        public UF UF => UF.AL;


        private readonly int[] tiposEmpresa = { 0, 3, 5, 7, 8, 4, 2, 1 };
        private readonly int[] pesos = { 9, 8, 7, 6, 5, 4, 3, 2 };

        public bool IsValid(string inscricaoEstadual)
        {
            if (inscricaoEstadual.Length != 9) return false;

            if (!inscricaoEstadual.StartsWith("24")) return false;

            if (!tiposEmpresa.Contains(int.Parse(inscricaoEstadual.Substring(2, 1)))) return false;


            string inscricaoSemDigito = inscricaoEstadual.Substring(0, 8);

            return inscricaoSemDigito + new DigitoVerificador().ObterDigitoMod11(inscricaoSemDigito, pesos).ToString() == inscricaoEstadual;
        }

        public string GenerateFake()
        {
            string inscricaoSemDigito = "24";

            Random rnd = new Random();
            double _random = rnd.NextDouble();
            int _x = 0;
            if (_random < 0.2) { _x = tiposEmpresa[0]; }
            else if (_random >= 0.2 && _random < 0.4) { _x = tiposEmpresa[1]; }
            else if (_random >= 0.4 && _random < 0.6) { _x = tiposEmpresa[2]; }
            else if (_random >= 0.6 && _random < 0.8) { _x = tiposEmpresa[3]; }
            else { _x = tiposEmpresa[4]; }

            inscricaoSemDigito += _x.ToString();
            for (int i = 0; i < 5; i++)
            {
                inscricaoSemDigito += rnd.Next(0, 9).ToString();
            }

            return inscricaoSemDigito + new DigitoVerificador().ObterDigitoMod11(inscricaoSemDigito, pesos).ToString();

        }
    }
}
