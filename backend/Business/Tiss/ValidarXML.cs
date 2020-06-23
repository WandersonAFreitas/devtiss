using System;
using System.IO;
using Business.Utils;
using Mapeamento.Dto.Enum;
using Mapeamento.Dto.ValidarXML;
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
            
                var versao = XmlUtils.RecuperaVersao(request.XML.OpenReadStream());

                if (String.IsNullOrEmpty(versao))
                    throw new Exception("Não foi possível identificar a versão TISS do arquivo ou o mesmo não está nas versões aceitas pela operadora.");

                var validar = Tiss.Versao.ValidarFactory.Validar(versao);
                
                validar.ValidarXML(request.XML.OpenReadStream(), versao, request.XML.FileName);

                response.Transacao  = validar.Transacao;
                response.Versao     = validar.Versao;
                response.Xml        = validar.Xml;

                if (!String.IsNullOrEmpty(validar.Ocorrencia))
                {
                    response.Situacao   = SituacaoEnum.ConcluidoComAlerta.Descricao(); 
                    response.Ocorrencia = validar.Ocorrencia;
                }
                else
                {
                    response.Situacao   = SituacaoEnum.Concluido.Descricao();
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
    }
}