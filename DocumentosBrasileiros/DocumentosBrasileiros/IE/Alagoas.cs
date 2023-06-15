using DocumentosBrasileiros.Enums;
using DocumentosBrasileiros.Helpers;
using DocumentosBrasileiros.Interfaces;
using System;
using System.Linq;

namespace DocumentosBrasileiros.IE
{
    /// <summary>
    /// 24XNNNNND
    /// 24- Código Estado
    /// X - Tipo de Empresa: 0-Normal, 3-Produtor Rural, 5-Substituta, 7- Micro-Empresa Ambulante, 8-Micro-Empresa, 4, 2 e 1 Não são oficiais
    /// NNNNN - Número da empresa
    /// D - Dígito verificador
    /// </summary>
    public class Alagoas : IInscricaoEstadual
    {
        public UfEnum UfEnum => UfEnum.AL;


        private readonly int[] _tiposEmpresa = { 0, 3, 5, 7, 8, 4, 2, 1 };
        private readonly int[] _pesos = { 9, 8, 7, 6, 5, 4, 3, 2 };

        public bool Validar(string inscricaoEstadual)
        {
            if (inscricaoEstadual.Length != 9) return false;

            if (!inscricaoEstadual.StartsWith("24")) return false;

            if (!_tiposEmpresa.Contains(int.Parse(inscricaoEstadual.Substring(2, 1)))) return false;


            string inscricaoSemDigito = inscricaoEstadual.Substring(0, 8);

            return inscricaoSemDigito + new DigitoVerificador().ObterDigitoMod11(inscricaoSemDigito, _pesos).ToString() == inscricaoEstadual;
        }

        public string GerarFake()
        {
            string inscricaoSemDigito = "24";

            Random rnd = new Random();
            double random = rnd.NextDouble();
            int _x = 0;
            if (random < 0.2) { _x = _tiposEmpresa[0]; }
            else if (random >= 0.2 && random < 0.4) { _x = _tiposEmpresa[1]; }
            else if (random >= 0.4 && random < 0.6) { _x = _tiposEmpresa[2]; }
            else if (random >= 0.6 && random < 0.8) { _x = _tiposEmpresa[3]; }
            else { _x = _tiposEmpresa[4]; }

            inscricaoSemDigito += _x.ToString();
            for (int i = 0; i < 5; i++)
            {
                inscricaoSemDigito += rnd.Next(0, 9).ToString();
            }

            return inscricaoSemDigito + new DigitoVerificador().ObterDigitoMod11(inscricaoSemDigito, _pesos).ToString();

        }
    }
}
