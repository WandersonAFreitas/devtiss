using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Business.Utils
{
    public class XmlUtils
    {
        private static String mensagensErros = String.Empty;
        private static String elementoErro = String.Empty;

        public static string ValidarXml(Stream xmlEntrada, Stream[] schemas)
        {
            try
            {
                var resolver = new XmlUrlResolver { Credentials = CredentialCache.DefaultCredentials };
                var xmlDoc = new XmlDocument { XmlResolver = resolver };

                xmlDoc.Load(xmlEntrada);

                if (xmlDoc.DocumentElement == null)
                    return String.Empty;

                xmlEntrada.Position = 0;

                var settings = CriarXmlReaderSettings(schemas);

                var reader = XmlReader.Create(xmlEntrada, settings);
                mensagensErros = String.Empty;
                elementoErro = String.Empty;

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Text)
                        elementoErro += reader.Value;
                }

                return mensagensErros;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + "\n" + e.InnerException);
            }
            finally
            {
                xmlEntrada.Position = 0;
            }

        }

        private static XmlReaderSettings CriarXmlReaderSettings(Stream[] schemas)
        {
            var settings = new XmlReaderSettings();

            foreach (var schema in schemas)
            {
                XmlSchema schemaXml = XmlSchema.Read(schema, null);
                settings.Schemas.Add(schemaXml);
            }

            settings.ValidationType = ValidationType.Schema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationEventHandler += new ValidationEventHandler(ErrosValidacaoXml);

            return settings;
        }

        private static void ErrosValidacaoXml(object sender, ValidationEventArgs e)
        {
            mensagensErros += "Erro: " + e.Message;

            if (elementoErro != String.Empty)
                mensagensErros += "\nConteúdo inválido: " + elementoErro;

            mensagensErros += "\nLinha: " + e.Exception.LineNumber +
                              "\nColuna: " + e.Exception.LinePosition + "\n\n";

        }
    
        public static string RecuperaVersao(Stream stream)
        {
            var versao = String.Empty;

            versao = XmlUtils.RecuperarValorXmlNo(stream, "Padrao");

            if (versao == String.Empty)
                versao = XmlUtils.RecuperarValorXmlNo(stream, "versaoPadrao");

            return versao;
        }

        public static string RecuperarValorXmlNo(Stream xml, string nomeNo)
        {
            xml.Position = 0;
            var reader = XmlReader.Create(xml, new XmlReaderSettings());
            
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && 
                   (reader.Name.Equals(nomeNo) || reader.Name.ToUpper().Contains(nomeNo.ToUpper())))
                {
                    reader.Read();
                    return reader.Value ?? String.Empty;
                }
            }

            return String.Empty;
        }

        public static object ConverterXmlParaClasse(Stream mensagem, Type type)
        {
            mensagem.Position = 0;
            XmlSerializer serializer = new XmlSerializer(type);
            try
            {
                return serializer.Deserialize(new XmlTextReader(mensagem));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}