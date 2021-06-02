using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProcessSystem.UI.Blazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using ProcessSystem.UI.Blazor.Server.Middleware;

namespace ProcessSystem.UI.Blazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {

        private readonly ILogger<RegisterController> _logger;
        private readonly ProcessSystemConnectOptions _config;

        public RegisterController(ILogger<RegisterController> logger, IOptions<ProcessSystemConnectOptions> options)
        {
            _logger = logger;
            _config = options.Value;
        }

        [HttpGet]
        public string Get()
        {
            return "Test";
        }
    }
}
