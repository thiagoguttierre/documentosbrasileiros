﻿using DocumentosBrasileiros.Enums;
using DocumentosBrasileiros.Helpers;
using System;

namespace DocumentosBrasileiros.Documentos.IE
{
    public class MatoGrosso : IDocumentoEstadual
    {
        public UF UF => UF.MT;

        private readonly int[] peso = { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        public bool IsValid(string inscricaoEstadual)
        {
            if (inscricaoEstadual.Length != 11) return false;

            string inscricaoSemDigito = inscricaoEstadual.Substring(0, 10);

            return inscricaoEstadual ==
             inscricaoSemDigito + new DigitoVerificador().ObterDigitoMod11(inscricaoSemDigito, peso).ToString();
        }

        public string GenerateFake()
        {
            string inscricaoSemDigito = "";
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                inscricaoSemDigito += rnd.Next(0, 9).ToString();
            }

            return inscricaoSemDigito + new DigitoVerificador().ObterDigitoMod11(inscricaoSemDigito, peso).ToString();
        }
    }
}