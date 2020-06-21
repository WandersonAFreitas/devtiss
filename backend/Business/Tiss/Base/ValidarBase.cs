using System;
using System.IO;
using System.Text;
using Business.Utils;

namespace Business.Tiss.Base
{
    public abstract class ValidarBase
    {
        protected Object mensagemTISS { get; set; }

        public String NomeFile { get; set; }
        public String Transacao { get; set; }
        public String Versao { get; set; }
        
        // public String Url { get; set; }
        public String Xml { get; set; }
        public String Ocorrencia { get; set; }

        public abstract void ValidarXML(Stream xml, String versao, String nomeFile);
        public abstract void ValidarSchema(Stream stream);
        public static bool ValidarHash(Stream stream)
        {
            return XmlUtils.ValidarHash(stream);
        }
    }
}