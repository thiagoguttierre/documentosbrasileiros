using DocumentosBrasileiros.Helpers;
using System;

namespace DocumentosBrasileiros
{
    public abstract class Documento
    {
        private string _numero;
        public string Numero
        {
            get => _numero;
            set => _numero = value.RemoveSpecialChars();
        }

        public bool DocumentoValido()
        {
            if (string.IsNullOrEmpty(Numero))
            {
                throw new Exception("Informe o número do documento");
            }
            
            return !Numero.AllCharsAreEqual() && Validar();
        }

        protected internal abstract bool Validar();
        public abstract string GerarFake();
    }
}