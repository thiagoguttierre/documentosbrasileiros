using System;
using System.Collections.Generic;
using System.Linq;
using DocumentosBrasileiros.Enums;
using DocumentosBrasileiros.IE;
using DocumentosBrasileiros.Interfaces;

namespace DocumentosBrasileiros
{
    public class InscricaoEstadual : Documento
    {
        public InscricaoEstadual(UfEnum uf)
        {
            Uf = uf;
        }

        public InscricaoEstadual(string numero, UfEnum uf)
        {
            Uf = uf;
            Numero = numero;
        }
        public InscricaoEstadual(string numero, int codigoIbgeUf)
        {
            Uf = (UfEnum)codigoIbgeUf;
            Numero = numero;
        }

        public UfEnum? Uf { get; set; }

        protected override bool Validar()
        {
            if (Uf == null)
            {
                throw new Exception("A UF do documento não foi informada");
            }

            return Numero.ToUpper().Equals("ISENTO") || GetEstado().Validar(Numero);
        }

        public override string GerarFake()
        {
            Numero = GetEstado().GerarFake();
            return Numero;
        }

        private IInscricaoEstadual GetEstado()
        {
            var ieEstados = new List<IInscricaoEstadual>
            {
                new Acre(),
                new Alagoas(),
                new Amapa(),
                new Amazonas(),
                new Bahia(),
                new Ceara(),
                new DistritoFederal(),
                new EspiritoSanto(),
                new Goias(),
                new Maranhao(),
                new MatoGrosso(),
                new MatoGrossoDoSul(),
                new MinasGerais(),
                new Para(),
                new Paraiba(),
                new Parana(),
                new Pernambuco(),
                new Piaui(),
                new RioDeJaneiro(),
                new RioGrandeDoNorte(),
                new RioGrandeDoSul(),
                new Rondonia(),
                new Roraima(),
                new SantaCatarina(),
                new SaoPaulo(),
                new Sergipe(),
                new Tocantins()
            };

            return ieEstados.FirstOrDefault(x => x.UfEnum == Uf);
        }
    }
}
