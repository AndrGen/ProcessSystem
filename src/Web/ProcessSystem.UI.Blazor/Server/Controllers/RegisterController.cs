using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProcessSystem.UI.Blazor.Server.ProcessSystemClient;

namespace ProcessSystem.UI.Blazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {

        private readonly ILogger<RegisterController> _logger;
        private readonly IClient _processSystemClient;
        public RegisterController(ILogger<RegisterController> logger, IClient processSystemClient)
        {
            _logger = logger;
            _processSystemClient = processSystemClient;
        }

        [HttpGet("Register")]
        public async Task<string> Get()
        {
           var result = await _processSystemClient.ApiRegisterRegisterurlAsync(new RegisterRequest()
            {
                Name = "Тест",
                Url = "localhost",
                ProcessTypesList = new List<string>()
                {
                    "ChangeSim"
                }
            });
            return result.Data;
        }
    }
}
