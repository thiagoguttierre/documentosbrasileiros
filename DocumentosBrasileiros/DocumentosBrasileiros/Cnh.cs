using DocumentosBrasileiros.Helpers;

namespace DocumentosBrasileiros
{
    public class Cnh : Documento
    {
        private readonly int[] _peso1 = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        private readonly int[] _peso2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public Cnh() { }
        public Cnh(string numero)
        {
            Numero = numero;
        }

        protected override bool Validar()
        {
            //verificando se o tamanho da string está correto
            if (Numero.Length != 11) return false;

            if (Numero.AllCharsAreEqual()) return false;
            string digitos = ObterDigitos(Numero);

            return Numero.EndsWith(digitos);
        }

        public override string GerarFake()
        {
            string cnh = "".RandomNumbers(9);
            Numero = cnh + ObterDigitos(cnh);

            return Numero;
        }


        private string ObterDigitos(string cnh)
        {
            var validadorDigito = new DigitoVerificador();
            int d1 = validadorDigito.ObterMod(cnh, _peso1);
            if (d1 > 9 || d1 == 1) d1 = 0;

            int d2 = validadorDigito.ObterMod(cnh, _peso2);
            if (d2 > 9 || d2 == 1) d2 = 0;

            return d1.ToString() + d2.ToString();
        }
    }
}