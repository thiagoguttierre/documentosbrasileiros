using DocumentosBrasileiros.Enums;
using DocumentosBrasileiros.Helpers;
using DocumentosBrasileiros.Interfaces;

namespace DocumentosBrasileiros.Documentos.IE
{
    public class Acre : IInscricaoEstadual
    {
        public UfEnum UfEnum => UfEnum.AC;

        private readonly int[] _peso = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        public bool Validar(string inscricaoEstadual)
        {
            if (inscricaoEstadual.Length != 13 || !inscricaoEstadual.StartsWith("01")) return false;

            string inscricaoSemDigito = inscricaoEstadual.Substring(0, 11);


            string digito1 = new DigitoVerificador().ObterDigitoMod11("0" + inscricaoSemDigito, _peso).ToString();

            string digito2 = new DigitoVerificador().ObterDigitoMod11(inscricaoSemDigito + digito1, _peso).ToString();

            return inscricaoSemDigito + digito1 + digito2 == inscricaoEstadual;
        }

        public string GerarFake()
        {
            string inscricaoSemDigito = "01".RandomNumbers(9);

            string digito1 = new DigitoVerificador().ObterDigitoMod11("0" + inscricaoSemDigito, _peso).ToString();
            string digito2 = new DigitoVerificador().ObterDigitoMod11(inscricaoSemDigito + digito1, _peso).ToString();

            return inscricaoSemDigito + digito1 + digito2;
        }
    }
}
