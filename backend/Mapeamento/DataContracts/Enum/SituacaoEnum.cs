using System;
using Microsoft.AspNetCore.Http;

namespace Mapeamento.DataContracts.Enum
{
    public enum SituacaoEnum
    {
        [System.Xml.Serialization.XmlEnumAttribute("Concluído")]
        Concluido = 1,

        [System.Xml.Serialization.XmlEnumAttribute("Concluído (Alerta)")]
        ConcluidoComAlerta = 2,

        [System.Xml.Serialization.XmlEnumAttribute("Erro")]
        Erro = 3,

        [System.Xml.Serialization.XmlEnumAttribute("Validando")]
        Validando = 4
    }
}