using DocumentosBrasileiros.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentosBrasileiros
{

    public interface ITipoDocumento
    {
        bool Validar(Documento documento);

        string GenerateFake(Documento documento);
    }

    public interface IDocumentoEstadual
    {
        UF UF { get; }

        bool IsValid(string documento);

        string GenerateFake();
    }
}
