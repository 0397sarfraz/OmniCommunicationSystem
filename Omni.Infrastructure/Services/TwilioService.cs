using Microsoft.Extensions.Configuration;
using Omni.Domain.Interfaces;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Omni.Infrastructure.Services
{
    public class TwilioService:ITwilioService
    {
        private readonly IConfiguration _configuration;
        public TwilioService(IConfiguration configuration)
        {
                _configuration = configuration;
            TwilioClient.Init(_configuration["Twilio:AccountSid"], _configuration["Twilio:AuthToken"]);
        }

        public async Task<string> MakeCallAsync(string toNumber)
        {
            var call=await CallResource.CreateAsync(
                to: new Twilio.Types.PhoneNumber(toNumber),
                from: new Twilio.Types.PhoneNumber(_configuration["Twilio:FromPhoneNumber"]),
                url: new Uri($"{_configuration["BaseUrl"]}/api/Voice/Gather-Input")
            );
            return call.Sid;
        }
    }
}
