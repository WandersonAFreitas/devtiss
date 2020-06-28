using System;
using Business.Tiss.Base;
using Mapeamento.Extensions;

using TissXsd30500 = Mapeamento.Tiss.V3_05_00;
using TissXsd30401 = Mapeamento.Tiss.V3_04_01;
using TissXsd30400 = Mapeamento.Tiss.V3_04_00;
using TissXsd30303 = Mapeamento.Tiss.V3_03_03;
using TissXsd30302 = Mapeamento.Tiss.V3_03_02;
using TissXsd30301 = Mapeamento.Tiss.V3_03_01;
using TissXsd30300 = Mapeamento.Tiss.V3_03_00;
using TissXsd30202 = Mapeamento.Tiss.V3_02_02;
using TissXsd30201 = Mapeamento.Tiss.V3_02_01;
using TissXsd30200 = Mapeamento.Tiss.V3_02_00;

namespace Business.Tiss.Versao
{
    public static class ValidarFactory
    {
        public static ValidarBase Validar(String versao)
        {
            ValidarBase validar = null;

            if (TissXsd30500.dm_versao.Item30500.Descricao().Equals(versao))
                validar = new Business.Tiss.Versao.V3_05_00.Validar();
            // else if (TissXsd30401.dm_versao.Item30401.Descricao().Equals(versao))
            //     validar = new Business.Tiss.Versao.V3_04_01.Validar();
            // else if (TissXsd30400.dm_versao.Item30400.Descricao().Equals(versao))
            //     validar = new Business.Tiss.Versao.V3_04_00.Validar();
            // else if (TissXsd30303.dm_versao.Item30303.Descricao().Equals(versao))
            //     validar = new Business.Tiss.Versao.V3_03_03.Validar();
            // else if (TissXsd30302.dm_versao.Item30302.Descricao().Equals(versao))
            //     validar = new Business.Tiss.Versao.V3_03_02.Validar();
            // else if (TissXsd30301.dm_versao.Item30301.Descricao().Equals(versao))
            //     validar = new Business.Tiss.Versao.V3_03_01.Validar();
            // else if (TissXsd30300.dm_versao.Item30300.Descricao().Equals(versao))
            //     validar = new Business.Tiss.Versao.V3_03_00.Validar();
            // else if (TissXsd30202.dm_versao.Item30202.Descricao().Equals(versao))
            //     validar = new Business.Tiss.Versao.V3_02_02.Validar();
            // else if (TissXsd30201.dm_versao.Item30201.Descricao().Equals(versao))
            //     validar = new Business.Tiss.Versao.V3_02_01.Validar();
            // else if (TissXsd30200.dm_versao.Item30200.Descricao().Equals(versao))
            //     validar = new Business.Tiss.Versao.V3_02_00.Validar();
            else
                throw new Exception("Não foi possível identificar a versão TISS do arquivo ou o mesmo não está nas versões aceitas pela operadora.");

            return validar;
        }

        public static String VersaoSuportada()
        {
            return TissXsd30500.dm_versao.Item30500.Descricao();
        }
    }
}