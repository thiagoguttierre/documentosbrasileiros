using DocumentosBrasileiros.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentosBrasileiros.Documentos
{
    public class Renavam : IDocumento
    {

        public readonly int[] pesos = { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        public bool Validar(Documento documento)
        {
            string renavam = documento.Numero;

            //Verifica o tamanho da string
            if (renavam.Length != 9 && renavam.Length != 11) return false;

            if (renavam.AllCharsAreEqual()) return false;

            //coloca 0 a esquerda caso o renavam tenha 9 dígitos
            renavam = Convert.ToInt64(renavam).ToString("00000000000");

            return renavam.EndsWith(ObterDigito(renavam));
        }
        public string GerarFake(Documento documento)
        {
            throw new NotImplementedException();
        }

        private string ObterDigito(string renavam)
        {
            int digito = new DigitoVerificador().ObterMod(renavam, pesos);
            digito = digito > 9 ? 0 : digito;
            return digito.ToString();
        }
    }
}
