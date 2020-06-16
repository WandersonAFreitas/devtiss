using System;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace Mapeamento.Extensions
{
    /// <summary>
    /// Classe responsavel por implementar os extensions metodos referentes a Enumerables
    /// </summary>
    public static class EnumExtensions
    {
        const string valorDefault = "Sem Descrição";
        /// <summary>
        /// Devolve a descrição do enum selecionado
        /// </summary>
        /// <param name="enumerador"></param>
        /// <returns>Descrição</returns>
        public static string Descricao(this Enum enumerador)
        {
            if (enumerador == null)
                return valorDefault;
            
            var fieldInfo = enumerador.GetType().GetMember(enumerador.ToString()).FirstOrDefault();
            var atributos = fieldInfo.GetCustomAttributes(false).OfType<XmlEnumAttribute>().FirstOrDefault();  

            return atributos.Name != "" ? atributos.Name ?? valorDefault : enumerador.ToString();
        }
    }
}