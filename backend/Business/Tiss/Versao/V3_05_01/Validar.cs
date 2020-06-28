using System;
using System.IO;
using System.Reflection;
using Business.Tiss.Base;
using Business.Utils;
using Mapeamento.Tiss.V3_05_00;

namespace Business.Tiss.Versao.V3_05_00
{
    public class Validar : ValidarBaseTiss<mensagemTISS>
    {
        public override void ValidarXML(Stream stream, String versao)
        {
            base.ValidarXML(stream, versao);

            this.Transacao = ((mensagemTISS)this.mensagem).cabecalho.identificacaoTransacao.tipoTransacao.ToString();
            this.versao = versao;

            if (!String.IsNullOrEmpty(this.NovoHash))
                ((mensagemTISS)this.mensagem).epilogo.hash = this.NovoHash;
            
            this.Xml = XmlUtils.SerializarClasseParaXmlUtf8<mensagemTISS>(this.mensagem);
        }
    }
}