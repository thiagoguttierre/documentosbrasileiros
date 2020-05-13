namespace DocumentosBrasileiros.Helpers
{
    internal class DigitoVerificador
    {
        //Obtem o mód de 11 da soma e subtrai 11 quando resto maior que 2
        public int ObterDigitoMod11(string numeroSemDigito, int[] peso)
        {
            int digito = ObterMod(numeroSemDigito, peso);

            return digito >= 2 ? 11 - digito : 0;
        }

        public int ObterDigitoMod9(string numeroSemDigito, int[] peso)
        {
            int digito = ObterMod(numeroSemDigito, peso, 9);

            return digito;
        }

        //Obtem o mód da soma;
        public int ObterMod(string numeroSemDigito, int[] peso, int mod = 11)
        {

            int soma = 0;
            for (int i = 0; i < peso.Length; ++i)
            {
                soma += peso[i] * int.Parse(numeroSemDigito[i].ToString());
            }

            return soma % mod;

        }
    }
}
