using DocumentosBrasileiros.Helpers;

namespace DocumentosBrasileiros
{
    public class Cnpj : Documento
    {
        private readonly int[] _pesos = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        
        public Cnpj() { }
        public Cnpj(string numero)
        {
            Numero = numero;
        }
        
        protected override bool Validar()
        {
            string cnpj = Numero;

            //verifica o tamanho da string 
            if (cnpj.Length != 14) return false;

            if (cnpj.AllCharsAreEqual()) return false;

            return cnpj.EndsWith(ObterDigitos(cnpj));
        }

        public override string GerarFake()
        {
            Numero = "".RandomNumbers(12);
            Numero = Numero + ObterDigitos(Numero);

            return Numero;
        }

        private string ObterDigitos(string cnpj)
        {
            var digitoVerificador = new DigitoVerificador();
            int d1 = digitoVerificador.ObterDigitoMod11("0" + cnpj, _pesos);
            int d2 = digitoVerificador.ObterDigitoMod11(cnpj + d1.ToString(), _pesos);

            return d1.ToString() + d2.ToString();
        }
    }
}