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

        protected abstract bool Validar();

        public bool DocumentoValido()
        {
            if (string.IsNullOrEmpty(Numero))
            {
                throw new Exception("Informe o número do documento");
            }

            return Validar();
        }

        public abstract string GerarFake();
    }
}