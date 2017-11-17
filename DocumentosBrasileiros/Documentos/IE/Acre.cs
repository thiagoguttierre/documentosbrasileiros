using DocumentosBrasileiros.Enums;
using DocumentosBrasileiros.Helpers;

namespace DocumentosBrasileiros.Documentos.IE
{
    public class Acre : IDocumentoEstadual
    {
        public UF UF => UF.AC;

        private readonly int[] peso = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        public bool IsValid(string inscricaoEstadual)
        {
            if (inscricaoEstadual.Length != 13 || !inscricaoEstadual.StartsWith("01")) return false;

            string inscricaoSemDigito = inscricaoEstadual.Substring(0, 11);


            string digito1 = new DigitoVerificador().ObterDigitoMod11("0" + inscricaoSemDigito, peso).ToString();

            string digito2 = new DigitoVerificador().ObterDigitoMod11(inscricaoSemDigito + digito1, peso).ToString();

            return inscricaoSemDigito + digito1 + digito2 == inscricaoEstadual;
        }

        public string GenerateFake()
        {
            string inscricaoSemDigito = "01".RandomNumbers(8);

            string digito1 = new DigitoVerificador().ObterDigitoMod11("0" + inscricaoSemDigito, peso).ToString();
            string digito2 = new DigitoVerificador().ObterDigitoMod11(inscricaoSemDigito + digito1, peso).ToString();

            return inscricaoSemDigito + digito1 + digito2;
        }


    }
}
