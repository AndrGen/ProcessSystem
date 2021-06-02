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
        private readonly IClient _processSystemClient
            ;
        public RegisterController(ILogger<RegisterController> logger, IClient processSystemClient)
        {
            _logger = logger;
            _processSystemClient = processSystemClient;
        }

        [HttpGet]
        public string Get()
        {
            return "Test";
        }
    }
}
