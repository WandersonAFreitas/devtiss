using System;
using Business.Tiss.Base;
using Mapeamento.Extensions;

using TissXsd30400 = Mapeamento.Tiss.V3_04_00;

namespace Business.Tiss.Versao
{
    public static class ValidarFactory
    {
        public static ValidarBase Validar(String versao)
        {
            ValidarBase validar = null;

            if (TissXsd30400.dm_versao.Item30400.Descricao().Equals(versao))
                validar = new Business.Tiss.Versao.V3_04_00.Validar();
            else
                throw new Exception("Não foi possível identificar a versão TISS do arquivo ou o mesmo não está nas versões aceitas pela operadora.");

            return validar;
        }
    }
}