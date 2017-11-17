using DocumentosBrasileiros.Documentos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentosBrasileiros
{
    public class TipoDocumento
    {
        public static TipoDocumento CNH = SetTipoDocumento<CNH>();
        public static TipoDocumento CNPJ = SetTipoDocumento<CNPJ>();
        public static TipoDocumento CPF = SetTipoDocumento<CPF>();
        public static TipoDocumento InscricaoEstadual = SetTipoDocumento<InscricaoEstadual>();
        public static TipoDocumento PIS = SetTipoDocumento<PIS>();
        public static TipoDocumento Renavam = SetTipoDocumento<Renavam>();


        public ITipoDocumento Documento { get { return (ITipoDocumento)Activator.CreateInstance(DocType); } }
        private Type DocType { get; set; }
        private static TipoDocumento SetTipoDocumento<T>() where T : ITipoDocumento
        {

            return new TipoDocumento
            {
                DocType = typeof(T),
                //Documento = Activator.CreateInstance<T>()
            };
        }
    }
}
