using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Business.Utils;
using Mapeamento.Tiss.V3_05_00;

namespace Business.Tiss.Base
{
    public class ValidarBaseTiss<T> : ValidarBase where T : class
    {
        private string RecuperaVersao(Stream stream)
        {
            var versao = String.Empty;

            versao = XmlUtils.RecuperarValorXmlNo(stream, "Padrao");

            if (versao == String.Empty)
                versao = XmlUtils.RecuperarValorXmlNo(stream, "versaoPadrao");

            return versao;
        }
        private bool ValidarHash(Stream stream, ref String oldHash, ref String newHash)
        {
            return Hash.ValidarHash(stream, ref oldHash, ref newHash);
        }
        private void ValidarSchema(Stream stream, string versao)
        {
            stream.Position = 0;
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

                this.Transacao = XmlUtils.RecuperarValorXmlNo(stream, "TipoTransacao"); 
                this.versao = RecuperaVersao(stream); 

                String newHash = String.Empty;
                String oldHash = String.Empty;

                if (!ValidarHash(stream, ref oldHash, ref newHash))
                {
                    this.Xml = XmlUtils.SetValorXmlNo(stream, oldHash, newHash);
                    this.Ocorrencia = "Arquivo Xml com Hash inválido.";
                }
                else
                {
                    stream.Position = 0;
                    StreamReader reader = new StreamReader( stream );
                    this.Xml = reader.ReadToEnd();
                }
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        
    }
}