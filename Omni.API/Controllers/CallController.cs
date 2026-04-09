using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Omni.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallController(ISender sender) : ControllerBase
    {
        [HttpPost("Make-call")]
        public async Task<IActionResult> MakeCall(string toNumber)
        {
            var response = await sender.Send(new Omni.Application.Command.MakeCallCommand(toNumber));
            return Ok($"Call initiated successfully.{response}");
        }
    }

}
