using DocumentosBrasileiros.Helpers;

namespace DocumentosBrasileiros.Documentos
{
    public class Cpf : Documento
    {
        private readonly int[] _pesos = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        protected override bool Validar()
        {
            string cpf = Numero;

            //verifica o tamanho da string 
            if (cpf.Length < 11) return false;

            if (cpf.AllCharsAreEqual()) return false;

            return cpf.EndsWith(ObterDigitos(cpf));
        }

        public override string GerarFake()
        {
            string cpf = "".RandomNumbers(9);
            Numero = cpf + ObterDigitos(cpf);

            return Numero;
        }

        private string ObterDigitos(string cpf)
        {
            DigitoVerificador digitoVerifador = new DigitoVerificador();
            int d1 = digitoVerifador.ObterDigitoMod11("0" + cpf, _pesos);
            int d2 = digitoVerifador.ObterDigitoMod11(cpf + d1.ToString(), _pesos);

            return d1.ToString() + d2.ToString();
        }
    }
}