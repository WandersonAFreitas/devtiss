using System;
using System.IO;

namespace Mapeamento.Dto.ValidarXML
{
    public class ValidarXMLResponse
    {
        public String key { get; set; }
        public String Nome { get; set; }
        public DateTime Data { get; set; }
        public String Transacao { get; set; }
        public String Versao { get; set; }
        public String Situacao { get; set; }

        // public String Url { get; set; }
        public String Xml { get; set; }
        public String Ocorrencia { get; set; }
    }
}
