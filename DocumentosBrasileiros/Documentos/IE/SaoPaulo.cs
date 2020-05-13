using DocumentosBrasileiros.Enums;
using System;
using DocumentosBrasileiros.Interfaces;

namespace DocumentosBrasileiros.Documentos.IE
{
    public class SaoPaulo : IInscricaoEstadual
    {
        public UfEnum UfEnum => UfEnum.SP;

        private readonly int[] pesos1 = { 1, 3, 4, 5, 6, 7, 8, 0 };
        private readonly int[] pesos2 = { 3, 2, 0, 9, 8, 7, 6, 5, 4, 3, 2 };
        public bool Validar(string valor)
        {
            if (valor.Length != 12 && valor.Length != 13)
                return false;

            string str;
            if (valor.Length == 13)
            {
                if (!valor.StartsWith("P"))
                    return false;
                int num = this.ObterDigito(valor.Substring(1, 8), pesos1, 7);
                str = string.Format("{0}{1}{2}", (object)valor.Substring(0, 9), (object)num, (object)valor.Substring(10, 3));
            }
            else
            {
                string substr = valor.Substring(0, 8);

                int digito1 = this.ObterDigito(substr, pesos1, 7);
                string valor2 = substr + (object)digito1 + valor.Substring(9, 2);

                int num2 = this.ObterDigito(valor2, pesos2, 2);
                str = string.Format("{0}{1}", (object)valor2, (object)num2);
            }
            if (str.Equals(valor))
                return true;
            return false;
        }

        private int ObterDigito(string valor, int[] pesos, int index)
        {
            int soma = Convert.ToInt32(valor.Substring(index, 1)) * 10;
            for (int i = 0; i < pesos.Length; ++i)
            {
                soma += pesos[i] * int.Parse(valor[i].ToString());
            }
            string str = (soma % 11).ToString();
            return Convert.ToInt32(str.Substring(str.Length - 1, 1));
        }

        public string GerarFake()
        {
            string inscricaoSemDigito = "";
            Random random = new Random();

            for (int i = 0; i < 8; i++)
            {
                inscricaoSemDigito += random.Next(0, 9).ToString();
            }

            inscricaoSemDigito += ObterDigito(inscricaoSemDigito, pesos1, 7).ToString();

            for (int i = 0; i < 2; i++)
            {
                inscricaoSemDigito += random.Next(0, 9).ToString();
            }
            inscricaoSemDigito += ObterDigito(inscricaoSemDigito, pesos2, 2).ToString();
            return inscricaoSemDigito;
        }
    }
}
