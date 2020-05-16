using System.Linq;
using DocumentosBrasileiros.Helpers;

namespace DocumentosBrasileiros
{
    public class Renavam : Documento
    {
        private readonly int[] _pesos = { 2, 3, 4, 5, 6, 7, 8, 9, 2, 3 };

        public Renavam() { }

        public Renavam(string numero)
        {
            Numero = numero;
        }

        protected internal override bool Validar()
        {
            string renavam = Numero;

            //Verifica o tamanho da string
            if (renavam.Length != 9 && renavam.Length != 11) return false;

            //coloca 0 a esquerda caso o renavam tenha 9 dígitos
            renavam = renavam.PadLeft(11, '0');

            var digito = ObterDigito(renavam.Substring(0, renavam.Length - 1));

            return renavam.EndsWith(digito);
        }

        public override string GerarFake()
        {
            string renavam = "".RandomNumbers(10);
            Numero = renavam + ObterDigito(renavam);
            
            return Numero;
        }

        private string ObterDigito(string renavam)
        {
            var reversoSemDigito = string.Join("", renavam.ToCharArray().Reverse());

            var mod11 = new DigitoVerificador().ObterMod(reversoSemDigito, _pesos);

            var digito = 11 - mod11;

            digito = digito >= 10 ? 0 : digito;

            return digito.ToString();
        }
    }
}