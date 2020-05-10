﻿using DocumentosBrasileiros.Enums;
using DocumentosBrasileiros.Helpers;
using System;

namespace DocumentosBrasileiros
{
    public class Documento
    {
        public string Numero { get; set; }
        public UfEnum? UF { get; set; }
        public IDocumento TipoDocumento { get; set; }

        public Documento(string numero, TipoDocumento tipoDocumento, UfEnum? uf = null)
        {
            this.Numero = numero.RemoveSpecialChars();
            this.TipoDocumento = tipoDocumento.Documento;
            this.UF = uf;
        }
        public Documento(TipoDocumento tipoDocumento, UfEnum? uf = null)
        {
            this.TipoDocumento = tipoDocumento.Documento;
            this.UF = uf;
        }

        public bool DocumentoValido()
        {
            if (TipoDocumento == null)
            {
                throw new Exception("Informe um tipo de documento");
            }
            if (string.IsNullOrEmpty(Numero))
            {
                throw new Exception("Informe o número do documento");
            }



            return TipoDocumento.Validar(this);
        }

        public void GerarDocumento()
        {
            if (TipoDocumento == null)
            {
                throw new Exception("Informe um tipo de documento");
            }
            if (TipoDocumento is IDocumentoEstadual && UF == null)
            {
                throw new Exception("É obrigatório informar uma UF para o tipo de documento selecionado");
            }

            this.Numero = TipoDocumento.GerarFake(this);
        }

    }
}
