using DocumentosBrasileiros.Enums;
using System;
using System.Linq;

namespace DocumentosBrasileiros.Documentos.IE
{
    /// <summary>
    /// Referencia da validação: http://www.sintegra.gov.br/Cad_Estados/cad_GO.html
    /// </summary>
    /// <param name="inscricaoEstadual"></param>
    /// <returns></returns>
    
    public class Goias : IDocumentoEstadual
    {
        public UfEnum UfEnum => UfEnum.GO;
      
        public bool Validar(string inscricaoEstadual)
        {
            if (inscricaoEstadual.Length != 9) return false;

            string ab = inscricaoEstadual.Substring(0, 2);
            if (ab != "10" && ab != "11" && ab != "15") return false;

            string inscricaoSemDigito = inscricaoEstadual.Substring(0, 8);//Remover o dígito verificador
            int digitoEsperado = int.Parse(inscricaoEstadual.Substring(8, 1));

            return ObterDigitosPossiveis(inscricaoSemDigito).Contains(digitoEsperado);
        }

        public int[] ObterDigitosPossiveis(string inscricaoSemDigito)
        {
            //Pre-validation

            if (inscricaoSemDigito == "11094402") return new int[2] { 0, 1 };
            int intIE = int.Parse(inscricaoSemDigito);


            int[] peso = new int[8] { 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;
            int dv = 0;

            for (int i = 0; i < 8; i++)
                soma += int.Parse(inscricaoSemDigito[i].ToString()) * peso[i];

            int resto = (soma % 11);

            if (resto == 0)
            {
                dv = 0;
            }
            else if (resto == 1 && intIE >= 10103105 && intIE <= 10119997)
            {
                dv = 1;
            }
            else if (resto == 1)
            {
                dv = 0;
            }
            else
            {
                dv = 11 - resto;
            }

            return new int[1] { dv };
        }

        public string GerarFake()
        {
            string inscricaoSemDigito = "";

            Random rnd = new Random();

            string[] ab = { "10", "11", "15" };

            double _ab = rnd.NextDouble();
            if (_ab < 0.33) { inscricaoSemDigito += ab[0]; }
            else if (_ab >= 0.33 && _ab < 0.66) { inscricaoSemDigito += ab[1]; }
            else { inscricaoSemDigito += ab[2]; }

            for (int i = 0; i < 6; i++)
            {
                inscricaoSemDigito += rnd.Next(0, 9).ToString();
            }

            return inscricaoSemDigito + ObterDigitosPossiveis(inscricaoSemDigito).First().ToString();
        }
    }
}
