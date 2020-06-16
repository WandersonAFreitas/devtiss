using System;
using System.IO;
using Business.Utils;
using Mapeamento.Dto.ValidarXML;
using Mapeamento.Extensions;
using TissXsd30400 = Mapeamento.Tiss.V3_04_00;
using TissBusiness30400 = Business.Tiss.V3_04_00;
using System.Collections.Generic;

namespace Business.Tiss
{
    public class ValidarXML
    {
        public ValidarXMLResponse Validar(ValidarXMLRequest request)
        {
            ValidarXMLResponse response = new ValidarXMLResponse();
            response.Situacao = SituacaoEnum.Validando.Descricao();

            try
            {

                if (!Path.GetExtension(request.XML.FileName).Equals(".XML", StringComparison.CurrentCultureIgnoreCase))
                    throw new Exception("O arquivo compactado não é de extensão XML.");
            
                var versao = XmlUtils.RecuperaVersao(request.XML.OpenReadStream());

                if (String.IsNullOrEmpty(versao))
                    throw new Exception("Não foi possível identificar a versão TISS do arquivo ou o mesmo não está nas versões aceitas pela operadora.");

                if (TissXsd30400.dm_versao.Item30400.Descricao().Equals(versao))
                {
                    new TissBusiness30400.Schema().Validar(request.XML.OpenReadStream());
                 
                    TissXsd30400.mensagemTISS mensagemTISS = (TissXsd30400.mensagemTISS)XmlUtils.ConverterXmlParaClasse(request.XML.OpenReadStream(), typeof(TissXsd30400.mensagemTISS));
                    response.Transacao = mensagemTISS.cabecalho.identificacaoTransacao.tipoTransacao.ToString();
                }
                else
                    throw new Exception("Versão invalida.");

                response.Versao = versao;
                response.Situacao = SituacaoEnum.Concluido.Descricao();
            }
            catch (System.Exception e)
            {
                response.Situacao = SituacaoEnum.Erro.Descricao();
                response.Ocorrencia = e.Message;
            }

            return response;

            // throw new NotImplementedException();
        }

        
    }
}