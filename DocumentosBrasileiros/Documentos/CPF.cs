using DocumentosBrasileiros.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentosBrasileiros.Documentos
{
    public class CPF : ITipoDocumento
    {
        public readonly int[] pesos = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        public bool Validar(Documento documento)
        {
            string cpf = documento.Numero;

            //verifica o tamanho da string 
            if (cpf.Length < 11) return false;

            if (cpf.AllCharsAreEqual()) return false;

            return cpf.EndsWith(ObterDigitos(cpf));
        }
        public string GenerateFake(Documento documento)
        {
            string cpf = "".RandomNumbers(8);

            return cpf + ObterDigitos(cpf);
        }

        private string ObterDigitos(string cpf)
        {
            DigitoVerificador digitoVerifador = new DigitoVerificador();
            int d1 = digitoVerifador.ObterDigitoMod11("0" + cpf, pesos);
            int d2 = digitoVerifador.ObterDigitoMod11(cpf + d1.ToString(), pesos);

            return d1.ToString() + d2.ToString();
        }
    }
}
