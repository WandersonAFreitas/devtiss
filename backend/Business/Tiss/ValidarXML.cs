using System;
using System.IO;
using Business.Utils;
using Mapeamento.DataContracts.Enum;
using Mapeamento.DataContracts.ValidarXML;
using Mapeamento.Extensions;

namespace Business.Tiss
{
    public class ValidarXML
    {
        public ValidarXMLResponse Validar(ValidarXMLRequest request)
        {
            ValidarXMLResponse response = new ValidarXMLResponse();
            response.Situacao = SituacaoEnum.Validando.Descricao();
            response.Nome     = request.XML.FileName;
            response.Data     = DateTime.Now;

            try
            {
                if (!Path.GetExtension(request.XML.FileName).Equals(".XML", StringComparison.CurrentCultureIgnoreCase))
                    throw new Exception("O arquivo compactado não é de extensão XML.");
            
                var versao = RecuperaVersao(request.XML.OpenReadStream());

                if (String.IsNullOrEmpty(versao))
                    throw new Exception("Não foi possível identificar a versão TISS do arquivo ou o mesmo não está nas versões aceitas.");

                var validar = Tiss.Versao.ValidarFactory.Validar(versao);
                validar.ValidarXML(request.XML.OpenReadStream(), versao);

                response.Transacao  = validar.Transacao;
                response.Versao     = validar.versao;
                response.Xml        = validar.Xml;
                response.Situacao   = SituacaoEnum.Concluido.Descricao();

                if (!String.IsNullOrEmpty(validar.Ocorrencia))
                {
                    response.Situacao   = SituacaoEnum.ConcluidoComAlerta.Descricao(); 
                    response.Ocorrencia = validar.Ocorrencia;
                }
            }
            catch (System.Exception e)
            {
                response.Situacao   = SituacaoEnum.Erro.Descricao();
                response.Ocorrencia = e.Message;
            }

            return response;
        }

        public String VersaoSuportada()
        {
            var versaoSuportada = Tiss.Versao.ValidarFactory.VersaoSuportada();

            return versaoSuportada;
        }

        private string RecuperaVersao(Stream stream)
        {
            var versao = String.Empty;

            versao = XmlUtils.RecuperarValorXmlNo(stream, "Padrao");

            if (versao == String.Empty)
                versao = XmlUtils.RecuperarValorXmlNo(stream, "versaoPadrao");

            return versao;
        }
    }
}