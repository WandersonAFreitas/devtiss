using Microsoft.AspNetCore.Http;

namespace Mapeamento.DataContracts.ValidarXML
{
    public class ValidarXMLRequest
    {
        public IFormFile XML { get; set; }
    }
}
