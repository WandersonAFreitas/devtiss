using System;
using System.Text;
using System.Threading.Tasks;
using Mapeamento.Dto.ValidarXML;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValidarXMLController : Base.ControllerBase
    {
        private readonly ILogger<ValidarXMLController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ValidarXMLController(ILogger<ValidarXMLController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public ValidarXMLResponse Post([FromForm] ValidarXMLRequest request)
        {
            ValidarXMLResponse response;

            try
            {
                _logger.LogInformation("Iniciando o processo de validação...");

                response = new Business.Tiss.ValidarXML().Validar(request, getCurrentUrl(_httpContextAccessor));

                _logger.LogInformation("Concluíndo o processo de validação...");

            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }

            return response;
        }

        // public async Task<IActionResult> Download(string xmlString)
        // {
        //     if (String.IsNullOrEmpty(xmlString))
        //         return Content("Arquivo inválido...");

        //     byte[] data = Encoding.UTF8.GetBytes(xmlString);
            
        //     FileStream fileStream = new FileStream(@path, FileMode.Create, FileAccess.Write);
        //     fileStream.Write(data, 0, data.Length);
        //     fileStream.Close();

        //     var memory = new MemoryStream();
        //     using (var stream = new FileStream(path, FileMode.Open))
        //     {
        //         await stream.CopyToAsync(memory);
        //     }
        //     memory.Position = 0;
        //     return File(memory, GetContentType(path), Path.GetFileName(path));
        // }
    }
}
