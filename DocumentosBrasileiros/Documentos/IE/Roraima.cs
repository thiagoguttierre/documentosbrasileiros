using DocumentosBrasileiros.Enums;
using DocumentosBrasileiros.Helpers;
using System;

namespace DocumentosBrasileiros.Documentos.IE
{
    public class Roraima : IDocumentoEstadual
    {
        public UfEnum UfEnum => UfEnum.SC;

        public readonly int[] peso = { 1, 2, 3, 4, 5, 6, 7, 8 };
        public bool Validar(string inscricaoEstadual)
        {
            if (inscricaoEstadual.Length != 9 || !inscricaoEstadual.StartsWith("24")) return false;

            string inscricaoSemDigito = inscricaoEstadual.Substring(0, 8);

            return inscricaoEstadual ==
            inscricaoSemDigito + new DigitoVerificador().ObterDigitoMod9(inscricaoSemDigito, peso).ToString();
        }

        public string GerarFake()
        {
            string inscricaoSemDigito = "24";
            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                inscricaoSemDigito += rnd.Next(0, 9).ToString();
            }

            return inscricaoSemDigito + new DigitoVerificador().ObterDigitoMod9(inscricaoSemDigito, peso);
        }

    }
}
