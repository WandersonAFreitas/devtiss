using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Business.Utils;

namespace Business.Tiss.Base
{
    public class ValidarBaseTiss<T> : ValidarBase where T : class
    {
        protected T mensagem { get; set; }

        public bool ValidarHash(Stream stream)
        {
            return XmlUtils.ValidarHash(stream);
        }

        public void ValidarSchema(Stream stream, string versao)
        {
            var assembly = Assembly.GetAssembly(typeof(T));

            var arquivosXsd = new List<Stream>();

            var _versao = versao.Replace(".", "_");

            arquivosXsd.Add(assembly.GetManifestResourceStream(String.Format("Tiss.V{0}.ArquivosAns.xsd.tissV{0}.xsd", _versao)));
            arquivosXsd.Add(assembly.GetManifestResourceStream(String.Format("Tiss.V{0}.ArquivosAns.xsd.tissWebServicesV{0}.xsd", _versao)));
            arquivosXsd.Add(assembly.GetManifestResourceStream(String.Format("Tiss.V{0}.ArquivosAns.xsd.tissAssinaturaDigital_v1.01.xsd", _versao)));
            arquivosXsd.Add(assembly.GetManifestResourceStream(String.Format("Tiss.V{0}.ArquivosAns.xsd.tissSimpleTypesV{0}.xsd", _versao)));
            arquivosXsd.Add(assembly.GetManifestResourceStream(String.Format("Tiss.V{0}.ArquivosAns.xsd.tissComplexTypesV{0}.xsd", _versao)));
            arquivosXsd.Add(assembly.GetManifestResourceStream(String.Format("Tiss.V{0}.ArquivosAns.xsd.tissGuiasV{0}.xsd", _versao)));
            arquivosXsd.Add(assembly.GetManifestResourceStream(String.Format("Tiss.V{0}.ArquivosAns.xsd.xmldsig-core-schema.xsd", _versao)));

            var erros = XmlUtils.ValidarXml(stream, arquivosXsd.ToArray());

            if (!String.IsNullOrEmpty(erros))
            {
                throw new Exception(String.Format("Erros na estrutura do arquivo XML, os seguintes erros foram encontrados: {0}.", erros));
            }
        }

        public override void ValidarXML(Stream stream, string versao)
        {
            try
            {
                this.ValidarSchema(stream, versao);

                this.mensagem = (T)XmlUtils.ConverterXmlParaClasse(stream, typeof(T));

                if (!ValidarHash(stream))
                {
                    this.Xml = XmlUtils.SerializarClasseParaXmlUtf8<T>((this.mensagem));

                    if (String.IsNullOrEmpty(this.Xml))
                        throw new Exception("Erro ao gerar arquivo de retorno.");

                    this.NovoHash = XmlUtils.CalcularHash(this.Xml);
                    this.Ocorrencia = "Arquivo Xml com Hash inválido.";
                }
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}