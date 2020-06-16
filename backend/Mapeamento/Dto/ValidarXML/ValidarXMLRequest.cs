using Microsoft.AspNetCore.Http;

namespace Mapeamento.Dto.ValidarXML
{
    public class ValidarXMLRequest
    {
        public IFormFile XML { get; set; }
    }
}
