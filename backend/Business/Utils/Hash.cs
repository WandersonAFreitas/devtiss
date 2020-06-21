using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using Business.Utils;
using Mapeamento.Extensions;

namespace Benner.Saude.Comuns
{
    public class Hash
    {
        public static string Gerar(string input)
        {
            var doc = new XmlDocument();                        
            doc.LoadXml(input);

            Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(input));
            string hashInformada = XmlUtils.RecuperarValorXmlNo(stream, "hash");

            var textoDoXml = ConversaoCaracteresXml.ConverterSimbolos(doc.InnerText);  
            var xmlSemHash = textoDoXml;

            if (!string.IsNullOrWhiteSpace(hashInformada))
                xmlSemHash = xmlSemHash.Replace(hashInformada, string.Empty);

            return Hash.GerarMd5(xmlSemHash);
        }

        public static string GerarMd5(string input)
        {            
            var md5 = MD5.Create();
            var inputBytes = Encoding.GetEncoding("ISO-8859-1").GetBytes(input);
            var hash = md5.ComputeHash(inputBytes);

            return GerarHexadecimal(hash);
        }

        private static string GerarHexadecimal(IEnumerable<byte> hash)
        {
            var sb = new StringBuilder();
            foreach (var t in hash)
                sb.Append(t.ToString("x2"));

            return sb.ToString();
        }
    }
}
