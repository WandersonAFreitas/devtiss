using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Xml;
using Business.Utils;

namespace Business.Tiss.Base
{
    public abstract class ValidarBase
    {
        public String Transacao { get; set; }
        public String versao { get; set; }
        public String Xml { get; set; }
        public String Ocorrencia { get; set; }
        public abstract void ValidarXML(Stream stream, String versao);
    }
}