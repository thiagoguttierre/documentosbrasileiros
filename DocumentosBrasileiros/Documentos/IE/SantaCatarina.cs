using DocumentosBrasileiros.Enums;
using DocumentosBrasileiros.Helpers;
using System;
using System.Linq;

namespace DocumentosBrasileiros.Documentos.IE
{
    public class SantaCatarina : IDocumentoEstadual
    {
        public UfEnum UfEnum => UfEnum.SC;

        private readonly int[] peso = new int[8] { 9, 8, 7, 6, 5, 4, 3, 2 };
        public bool Validar(string ie)
        {
            if (ie.Length != 9) return false; //faltando caracteres?
            if (ie.Distinct().Count() == 1) return false; //todos os digitos iguais?

            string digitoEsperado = ie.Substring(8, 1);
            string inscricaoSemDigito = ie.Substring(0, 8);

            return new DigitoVerificador().ObterDigitoMod11(inscricaoSemDigito, peso).ToString() == digitoEsperado;
        }


        public string GerarFake()
        {
            string inscricaoSemDigito = "";

            Random rnd = new Random();
            for (int i = 0; i < 8; i++)
            {
                inscricaoSemDigito += rnd.Next(0, 9).ToString();
            }

            string digito = new DigitoVerificador().ObterDigitoMod11(inscricaoSemDigito, peso).ToString();

            return inscricaoSemDigito + digito;
        }
    }
}
