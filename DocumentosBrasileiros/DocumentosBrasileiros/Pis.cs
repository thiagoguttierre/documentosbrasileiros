using DocumentosBrasileiros.Helpers;

namespace DocumentosBrasileiros
{
    public class Pis : Documento
    {
        private readonly int[] _pesos = { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        public Pis() { }
        public Pis(string numero)
        {
            Numero = numero;
        }

        protected internal override bool Validar()
        {
            string pis = Numero;

            //Verifica o tamanho da string
            if (pis.Length != 11) return false;

            return pis.EndsWith(ObterDigitos(pis));
        }

        public override string GerarFake()
        {
            string pis = "".RandomNumbers(10);
            Numero = pis + ObterDigitos(pis);

            return Numero;
        }

        private string ObterDigitos(string pis)
        {
            return new DigitoVerificador().ObterDigitoMod11(pis, _pesos).ToString();
        }
    }
}