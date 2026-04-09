using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Omni.Application.Command;
using Omni.Application.Queries;
using System.Net.Http.Headers;
using System.Text;
using Twilio.TwiML;
using Twilio.TwiML.Voice;

namespace Omni.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoiceController(ISender sender, IConfiguration _configuration) : ControllerBase
    {
        [HttpPost("Start")]
        public async Task<IActionResult> Start()
        {
            var callSid = Request.Form["CallSid"];
            var from = Request.Form["From"];
            var to = Request.Form["To"];

            await sender.Send(new CreateCallLogCommand(callSid, from, to));
            var menu= await sender.Send(new GetIVRMenuQuery());

            var response = new VoiceResponse();

            var gather = new Gather(
                numDigits: 1,
                action: new Uri($"/api/Voice/process?", UriKind.Relative),
                method: "POST"
            );

            gather.Say(menu.Message);
            response.Append(gather);

            return Content(response.ToString(), "text/xml");
        }

        [HttpPost("process")]
        public async Task<IActionResult> Process()
        {
            var digit = Request.Form["Digits"];
            var callSid = Request.Form["CallSid"];

            if(!string.IsNullOrEmpty(callSid) && !string.IsNullOrEmpty(digit))
            {
                await sender.Send(new SaveCallActionCommand(callSid, digit));
            }

            var menu = await sender.Send(new GetIVRMenuByDigitQuery(digit));

            var response = new VoiceResponse();

            if (menu.ActionType == "Transfer")
            {
                var dial = new Dial(
                    record: Dial.RecordEnum.RecordFromAnswer,
                    action: new Uri("/api/Voice/call-status", UriKind.Relative),
                    method: "POST",                    
                    recordingStatusCallback: new Uri("/api/Voice/recording-callback", UriKind.Relative)
                );

                dial.Number(menu.ActionValue);
                response.Append(dial);
            }
            else if (menu.ActionType == "Record")
            {
                response.Say(menu.Message);
                response.Record(
                    maxLength: 30,
                    action: new Uri("api/Voice/recording-callback", uriKind:UriKind.Relative),
                    method: "POST"
                );
            }

            return Content(response.ToString(), "text/xml");
        }

        [HttpPost("call-status")]
        public async Task<IActionResult> CallStatus()
        {
            var callSid = Request.Form["CallSid"];
            var status = Request.Form["CallStatus"];
            var duration = Request.Form["CallDuration"];

            await sender.Send(new UpdateCallStatusCommand(callSid, status, duration));

            var response = new VoiceResponse();

            return Content(response.ToString(), "text/xml");
        }
        [HttpPost("recording-callback")]
        public async Task<IActionResult> RecordingCallback()
        {
            var callSid = Request.Form["CallSid"];
            var recordingUrl = Request.Form["RecordingUrl"];
            var duration = Request.Form["RecordingDuration"];

            await sender.Send(new UpdateRecordingCommand(callSid, recordingUrl, duration));

            return Ok();
        }
        [HttpGet("play-recording")]
        public async Task<IActionResult> PlayRecording(string url)
        {
            var accountSid = _configuration["Twilio:AccountSid"];
            var authToken = _configuration["Twilio:AuthToken"];

            var client = new HttpClient();
            var byteArray = Encoding.ASCII.GetBytes($"{accountSid}:{authToken}");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var audioBytes = await client.GetByteArrayAsync(url + ".mp3");

            return File(audioBytes, "audio/mpeg");
        }

    }
}
