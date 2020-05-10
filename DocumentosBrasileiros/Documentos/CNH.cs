using DocumentosBrasileiros.Helpers;

namespace DocumentosBrasileiros.Documentos
{
    public class Cnh : IDocumento
    {
        private readonly int[] peso1 = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        private readonly int[] peso2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public bool Validar(Documento documento)
        {
            //verificando se o tamanho da string está correto
            if (documento.Numero.Length != 11) return false;

            if (documento.Numero.AllCharsAreEqual()) return false;
            string digitos = ObterDigitos(documento.Numero);

            return documento.Numero.EndsWith(digitos);
        }

        public string GerarFake(Documento documento)
        {
            string cnh = "".RandomNumbers(8);

            return cnh + ObterDigitos(cnh);
        }


        private string ObterDigitos(string cnh)
        {
            var validadorDigito = new DigitoVerificador();
            int d1 = validadorDigito.ObterMod(cnh, peso1);
            if (d1 > 9 || d1 == 1) d1 = 0;

            int d2 = validadorDigito.ObterMod(cnh, peso2);
            if (d2 > 9 || d2 == 1) d2 = 0;

            return d1.ToString() + d2.ToString();
        }

    }
}
