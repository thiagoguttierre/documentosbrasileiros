using DocumentosBrasileiros.Documentos;
using System;


namespace DocumentosBrasileiros
{
    public class TipoDocumento
    {
        public static TipoDocumento Cnh = SetTipoDocumento<Cnh>();
        public static TipoDocumento Cnpj = SetTipoDocumento<Cnpj>();
        public static TipoDocumento Cpf = SetTipoDocumento<Cpf>();
        public static TipoDocumento InscricaoEstadual = SetTipoDocumento<InscricaoEstadual>();
        public static TipoDocumento Pis = SetTipoDocumento<Pis>();
        public static TipoDocumento Renavam = SetTipoDocumento<Renavam>();


        public IDocumento Documento => (IDocumento)Activator.CreateInstance(DocType);
        private Type DocType { get; set; }
        private static TipoDocumento SetTipoDocumento<T>() where T : IDocumento
        {

            return new TipoDocumento
            {
                DocType = typeof(T),
                //Documento = Activator.CreateInstance<T>()
            };
        }
    }
}
