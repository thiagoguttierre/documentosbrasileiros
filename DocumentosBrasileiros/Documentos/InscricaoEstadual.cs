using DocumentosBrasileiros.Documentos.IE;
using DocumentosBrasileiros.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DocumentosBrasileiros.Documentos
{
    public class InscricaoEstadual : ITipoDocumento
    {
        public bool Validar(Documento documento)
        {
            if (documento.UF == null)
            {
                throw new Exception("A UF do documento não foi informada");
            }

            string inscricao = documento.Numero;

            if (inscricao.ToUpper().Equals("ISENTO")) return true;

            IDocumentoEstadual validacaoIE = GetEstado(documento);

            return validacaoIE.IsValid(documento.Numero);
        }

        public string GenerateFake(Documento documento)
        {
            IDocumentoEstadual validacaoIE = GetEstado(documento);

            return validacaoIE.GenerateFake();
        }

        private IDocumentoEstadual GetEstado(Documento documento)
        {
            // System.Reflection.Assembly assembly = System.Reflection.Assembly.GetEntryAssembly();

            //var allClasses =  assembly.DefinedTypes
            //     .Where(type => type.ImplementedInterfaces.Contains(typeof(IDocumentoEstadual)));
            // return assembly.DefinedTypes
            //     .Where(type => type.ImplementedInterfaces.Contains(typeof(IDocumentoEstadual)) && type.Namespace.Contains("IE"))
            //     .Select(x => assembly.CreateInstance(x.FullName) as IDocumentoEstadual).FirstOrDefault(x => x.UF == documento.UF);


            List<IDocumentoEstadual> ieEstados = new List<IDocumentoEstadual>
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

            return ieEstados.FirstOrDefault(x => x.UF == documento.UF);
        }
    }
}
