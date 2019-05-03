using System.Threading.Tasks;
using KinoG.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KinoG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationService _authenticationService;

        public AuthenticationController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [Authorize]
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult("(_!_)");
        }

        [HttpPost]
        public async Task<string> Post([FromBody]string googleToken)
        {
            return await _authenticationService.GetTokenAsync(googleToken);
        }
    }
}