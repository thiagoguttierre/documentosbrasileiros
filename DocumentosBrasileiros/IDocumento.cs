using DocumentosBrasileiros.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentosBrasileiros
{
    public interface IDocumento
    {
        bool Validar(Documento documento);

        string GerarFake(Documento documento);
    }

    public interface IDocumentoEstadual
    {
        UfEnum UfEnum { get; }

        bool Validar(string documento);

        string GerarFake();
    }
}
