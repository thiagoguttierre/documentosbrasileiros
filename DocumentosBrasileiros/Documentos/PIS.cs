using DocumentosBrasileiros.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentosBrasileiros.Documentos
{
    public class Pis : IDocumento
    {
        private readonly int[] pesos = { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        public bool Validar(Documento documento)
        {
            string pis = documento.Numero;

            //Verifica o tamanho da string
            if (pis.Length != 11) return false;

            if (pis.AllCharsAreEqual()) return false;

            return pis.EndsWith(ObterDigitos(pis));
        }

        public string GerarFake(Documento documento)
        {
            string pis = "".RandomNumbers(9);

            return pis + ObterDigitos(pis);
        }

        private string ObterDigitos(string pis)
        {
            return new DigitoVerificador().ObterDigitoMod11(pis, pesos).ToString();
        }

    }
}
