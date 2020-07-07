using System;
using System.IO;

namespace Mapeamento.DataContracts.ValidarXML
{
    public class ValidarXMLResponse
    {
        public String Nome { get; set; }
        public DateTime Data { get; set; }
        public String Transacao { get; set; }
        public String Versao { get; set; }
        public String Situacao { get; set; }
        public String Xml { get; set; }
        public String Ocorrencia { get; set; }
    }
}
