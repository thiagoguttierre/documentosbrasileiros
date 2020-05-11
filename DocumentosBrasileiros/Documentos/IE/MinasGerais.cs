using DocumentosBrasileiros.Enums;
using System;
using System.Linq;
using DocumentosBrasileiros.Interfaces;

namespace DocumentosBrasileiros.Documentos.IE
{
    /// <summary>
    /// Referencia da validação: http://www.sintegra.gov.br/Cad_Estados/cad_GO.html
    /// </summary>
    /// <param name="inscricaoEstadual"></param>
    /// <returns></returns>
    public class MinasGerais:IInscricaoEstadual
    {
        public UfEnum UfEnum => UfEnum.MG;

        public bool Validar(string inscricaoEstadual)
        {
            if (inscricaoEstadual.Length != 13)
                return false;

            string inscricaoSemDigito = inscricaoEstadual.Substring(0, 11);

            int digito1 = this.ObterDigito1(inscricaoSemDigito);

            int digito2 = this.ObterDigito2(inscricaoSemDigito, digito1.ToString());

            return inscricaoSemDigito + digito1.ToString() + digito2.ToString() == inscricaoEstadual;

        }

        private int ObterDigito1(string inscricaoSemDigito)
        {
            int[] _pesos = { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            string inscricaoEstadualIgualada = inscricaoSemDigito.Substring(0, 3) + "0" + inscricaoSemDigito.Substring(3, 8);

            int soma = 0;
            for (int i = 0; i < _pesos.Length; ++i)
            {
                int resultadoMultiplicacao = _pesos[i] * Convert.ToInt32(inscricaoEstadualIgualada[i].ToString());

                //somar os digitos do resultado da multiplicação do peso[i] * ie[i]. Exemplo: Se n = 1, soma+=1. Se n = 11, soma=+ 1+1
                while (resultadoMultiplicacao != 0)
                {
                    soma += resultadoMultiplicacao % 10;
                    resultadoMultiplicacao /= 10;
                }
            }

            int proximaDezenaExata = 10 - (soma % 10) + soma;
            int digito = proximaDezenaExata - soma == 10 ? 0 : proximaDezenaExata - soma;
            return digito;
        }

        private int ObterDigito2(string inscricaoSemDigito, string digito1)
        {
            int[] _pesos = { 3, 2, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string ie = inscricaoSemDigito + digito1;

            int soma = 0;
            for (int i = 0; i < ie.Count(); i++)
            {
                soma += Convert.ToInt32(ie[i].ToString()) * _pesos[i];
            }
            int resto = (soma % 11);
            int digito = resto <= 1 ? 0 : 11 - resto;

            return digito;
        }

        public string GerarFake()
        {
            string inscricaoSemDigito = "";

            Random rnd = new Random();
            for (int i = 0; i < 11; i++)
            {
                inscricaoSemDigito += rnd.Next(0, 9).ToString();
            }

            int digito1 = ObterDigito1(inscricaoSemDigito);
            int digito2 = ObterDigito2(inscricaoSemDigito, digito1.ToString());

            return inscricaoSemDigito + digito1.ToString() + digito2.ToString();
        }
    }
}
