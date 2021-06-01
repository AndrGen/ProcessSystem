using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProcessSystem.UI.Blazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessSystem.UI.Blazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {

        private readonly ILogger<RegisterController> _logger;

        public RegisterController(ILogger<RegisterController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "Test";
        }
    }
}
