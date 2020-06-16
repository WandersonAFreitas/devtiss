using System;
using Mapeamento.Dto.ValidarXML;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValidarXMLController : ControllerBase
    {
        private readonly ILogger<ValidarXMLController> _logger;

        public ValidarXMLController(ILogger<ValidarXMLController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ValidarXMLResponse Post([FromForm] ValidarXMLRequest request)
        {
            ValidarXMLResponse response;

            try
            {
                _logger.LogInformation("Iniciando o processo de validação...");
                
                response = new Business.Tiss.ValidarXML().Validar(request);

                _logger.LogInformation("Concluíndo o processo de validação...");
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }

            return response;
        }
    }
}
