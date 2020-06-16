using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Business.Utils;
using Mapeamento.Tiss.V3_04_00;

namespace Business.Tiss.V3_04_00
{
    public class Schema
    {
        public void Validar(Stream stream)
        {
            var assembly = Assembly.GetAssembly(new mensagemTISS().GetType());

            var arquivosXsd = new List<Stream>();

            arquivosXsd.Add(assembly.GetManifestResourceStream("Tiss.V3_04_00.ArquivosAns.xsd.tissV3_04_00.xsd"));
            arquivosXsd.Add(assembly.GetManifestResourceStream("Tiss.V3_04_00.ArquivosAns.xsd.tissAssinaturaDigital_v1.01.xsd"));
            arquivosXsd.Add(assembly.GetManifestResourceStream("Tiss.V3_04_00.ArquivosAns.xsd.tissSimpleTypesV3_04_00.xsd"));
            arquivosXsd.Add(assembly.GetManifestResourceStream("Tiss.V3_04_00.ArquivosAns.xsd.tissComplexTypesV3_04_00.xsd"));
            arquivosXsd.Add(assembly.GetManifestResourceStream("Tiss.V3_04_00.ArquivosAns.xsd.tissGuiasV3_04_00.xsd"));
            arquivosXsd.Add(assembly.GetManifestResourceStream("Tiss.V3_04_00.ArquivosAns.xsd.xmldsig-core-schema.xsd"));             
            
            var erros = XmlUtils.ValidarXml(stream, arquivosXsd.ToArray());

            if (!String.IsNullOrEmpty(erros))
            {
                throw new Exception(String.Format("Erros na estrutura do arquivo XML, os seguintes erros foram encontrados: {0}.", erros));
            }
        }
    }
}