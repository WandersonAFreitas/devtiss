using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Business.Tiss.Base;
using Business.Utils;

using Mapeamento.Tiss.V3_05_00;

namespace Business.Tiss.Versao.V3_05_00
{
    public class Validar : ValidarBase
    {
        public override void ValidarXML(Stream xml, String versao, String nomeFile)
        {
            try
            {
                ValidarSchema(xml);

                this.mensagemTISS = (mensagemTISS)XmlUtils.ConverterXmlParaClasse(xml, typeof(mensagemTISS));
                
                this.Transacao = ((mensagemTISS)this.mensagemTISS).cabecalho.identificacaoTransacao.tipoTransacao.ToString();
                this.Versao = versao;
                this.NomeFile = nomeFile;

                if (!ValidarHash(xml))
                {
                    this.Xml = XmlUtils.SerializarClasseParaXmlUtf8<mensagemTISS>(((mensagemTISS)this.mensagemTISS));

                    if (String.IsNullOrEmpty(this.Xml))
                        throw new Exception("Erro ao gerar arquivo de retorno.");

                    ((mensagemTISS)this.mensagemTISS).epilogo.hash = XmlUtils.CalcularHash(this.Xml);

                    this.Ocorrencia = "Arquivo Xml com Hash inválido.";
                }

                this.Xml = XmlUtils.SerializarClasseParaXmlUtf8<mensagemTISS>(((mensagemTISS)this.mensagemTISS));
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override void ValidarSchema(Stream stream)
        {
            var assembly = Assembly.GetAssembly(new mensagemTISS().GetType());

            var arquivosXsd = new List<Stream>();

            arquivosXsd.Add(assembly.GetManifestResourceStream("Tiss.V3_05_00.ArquivosAns.xsd.tissV3_05_00.xsd"));
            arquivosXsd.Add(assembly.GetManifestResourceStream("Tiss.V3_05_00.ArquivosAns.xsd.tissAssinaturaDigital_v1.01.xsd"));
            arquivosXsd.Add(assembly.GetManifestResourceStream("Tiss.V3_05_00.ArquivosAns.xsd.tissSimpleTypesV3_05_00.xsd"));
            arquivosXsd.Add(assembly.GetManifestResourceStream("Tiss.V3_05_00.ArquivosAns.xsd.tissComplexTypesV3_05_00.xsd"));
            arquivosXsd.Add(assembly.GetManifestResourceStream("Tiss.V3_05_00.ArquivosAns.xsd.tissGuiasV3_05_00.xsd"));
            arquivosXsd.Add(assembly.GetManifestResourceStream("Tiss.V3_05_00.ArquivosAns.xsd.xmldsig-core-schema.xsd"));

            var erros = XmlUtils.ValidarXml(stream, arquivosXsd.ToArray());

            if (!String.IsNullOrEmpty(erros))
            {
                throw new Exception(String.Format("Erros na estrutura do arquivo XML, os seguintes erros foram encontrados: {0}.", erros));
            }
        }
    }
}