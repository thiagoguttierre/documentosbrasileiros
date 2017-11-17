using DocumentosBrasileiros.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentosBrasileiros.Documentos
{
    public class CNPJ : ITipoDocumento
    {
        private readonly int[] pesos = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        public bool Validar(Documento documento)
        {
            string cnpj = documento.Numero;

            //verifica o tamanho da string 
            if (cnpj.Length != 14) return false;

            if (cnpj.AllCharsAreEqual()) return false;

            return cnpj.EndsWith(ObterDigitos(cnpj));
        }
        public string GenerateFake(Documento documento)
        {
            string cnpj = "".RandomNumbers(11);

            return cnpj + ObterDigitos(cnpj);
        }

        private string ObterDigitos(string cnpj)
        {
            var digitoVerificador = new DigitoVerificador();
            int d1 = digitoVerificador.ObterDigitoMod11("0" + cnpj, pesos);
            int d2 = digitoVerificador.ObterDigitoMod11(cnpj + d1.ToString(), pesos);

            return d1.ToString() + d2.ToString();
        }
    }
}
