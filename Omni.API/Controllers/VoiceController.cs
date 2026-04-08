using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twilio.TwiML;
using Twilio.TwiML.Voice;

namespace Omni.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoiceController : ControllerBase
    {
        [HttpPost("Gather-Input")]
        public async Task<IActionResult> GatherInput()
        {
            VoiceResponse response = new VoiceResponse();
            response.Say("Please enter your input followed by the pound key.");
            var gather = new Gather(numDigits: 1, action: new Uri("/api/Voice/ProcessInput", UriKind.Relative), method: "POST");

            response.Append(gather);

            return Content(response.ToString(), "text/xml");
        }

        [HttpPost("ProcessInput")]
        public async Task<IActionResult> ProcessInput()
        {
            var digits = Request.Form["Digits"];    
            if (digits == "1")
            {
                VoiceResponse response = new VoiceResponse();
                response.Say("You entered 1. Thank you for your input.");
                return Content(response.ToString(), "text/xml");
            }
            else
            {
                VoiceResponse response = new VoiceResponse();
                response.Say("Invalid input. Please try again.");
                var gather = new Gather(numDigits: 1, action: new Uri("/api/Voice/ProcessInput", UriKind.Relative), method: "POST");
                response.Append(gather);
                return Content(response.ToString(), "text/xml");
            }

        }
    }
}
