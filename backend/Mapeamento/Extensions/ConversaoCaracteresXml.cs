using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace Mapeamento.Extensions
{
    public static class ConversaoCaracteresXml
    {
        private const string E_COMERCIAL_SIMBOLO = "&";
        private const string MENOR_SIMBOLO = "<";

        private const string E_COMERCIAL_CONVERSAO = "&amp;";
        private const string MENOR_CONVERSAO = "&lt;";

        private static readonly Dictionary<string, string> DicionarioCaracteres = new Dictionary<string, string>
        {
            {E_COMERCIAL_SIMBOLO, E_COMERCIAL_CONVERSAO},
            {MENOR_SIMBOLO, MENOR_CONVERSAO}
        };

        public static string ConverterSimbolos(string texto)
        {
            var textoConverter = texto;

            foreach (var key in DicionarioCaracteres.Keys)
            {
                textoConverter = textoConverter.Replace(key, DicionarioCaracteres[key]);
            }

            return textoConverter;
        }
    }
}