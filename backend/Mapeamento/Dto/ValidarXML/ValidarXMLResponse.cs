using System;

namespace Mapeamento.Dto.ValidarXML
{
    public enum SituacaoEnum
    {
        [System.Xml.Serialization.XmlEnumAttribute("Concluído")]
        Concluido = 1,

        [System.Xml.Serialization.XmlEnumAttribute("Erro")]
        Erro = 2,

        [System.Xml.Serialization.XmlEnumAttribute("Validando")]
        Validando = 3
    }
    public class ValidarXMLResponse
    {
        public DateTime Date { get; set; }
        public String Transacao { get; set; }
        public String Versao { get; set; }
        public String Situacao { get; set; }
        public String XML { get; set; }
        public String Ocorrencia { get; set; }
    }
}
