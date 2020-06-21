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
        // public void SaveFile()
        // {
        //     string hash = new Random(DateTime.Now.Ticks.GetHashCode()).Next(1, 1000000).ToString();

        //     var nomeFile = String.Format("[{0}]-{1}", hash, NomeFile);

        //     Url = String.Concat("/Xml/", nomeFile);

        //     var path = Path.Combine(
        //           Directory.GetCurrentDirectory(),
        //           "wwwroot", "xml",
        //           nomeFile);

        //     if (!Directory.Exists(Path.GetDirectoryName(@path)))
        //         Directory.CreateDirectory(Path.GetDirectoryName(@path));

        //     if (File.Exists(@path))
        //         File.Delete(@path);

        //     byte[] data = Encoding.UTF8.GetBytes(XmlString);
        //     FileStream fileStream = new FileStream(@path, FileMode.Create, FileAccess.Write);
        //     fileStream.Write(data, 0, data.Length);
        //     fileStream.Close();
        // }
    }
}