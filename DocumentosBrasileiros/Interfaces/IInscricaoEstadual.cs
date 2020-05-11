using DocumentosBrasileiros.Enums;

namespace DocumentosBrasileiros.Interfaces
{
    public interface IInscricaoEstadual
    {
        UfEnum UfEnum { get; }

        bool Validar(string inscricaoEstadual);
        string GerarFake();
    }
}