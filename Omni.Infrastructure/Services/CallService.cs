using Microsoft.EntityFrameworkCore;
using Omni.Domain.Entities;
using Omni.Domain.Interfaces;
using Omni.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Infrastructure.Services
{
    public class CallService(AppDbContext _context) : ICallService
    {
        public async Task CreateCallLog(string callSid, string from, string to)
        {
            await _context.CallLogs.AddAsync(new CallLog
            {
                CallSid = callSid,
                FromNumber = from,
                ToNumber = to,
                Status = "initiated",
                StartTime = DateTime.UtcNow,
                CompanyId = 1
            });

            await _context.SaveChangesAsync();
        }

        public async Task SaveAction(string callSid, string digit)
        {

            var call = await _context.CallLogs.FirstOrDefaultAsync(x => x.CallSid == callSid);

            if (call != null)
            {
                await _context.CallActions.AddAsync(new CallAction
                {
                    CallLogId = call.Id,
                    DigitPressed = int.Parse(digit),
                    ActionType = "IVR Input"
                });

                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateRecording(string callSid, string url, string duration)
        {
            var call = await _context.CallLogs.FirstOrDefaultAsync(x => x.CallSid == callSid);
            if(call != null) {
                call.RecordingUrl = url;
                call.Duration = int.Parse(duration);

                await _context.SaveChangesAsync();
            }
         
        }

        public async Task UpdateStatus(string callSid, string status, string duration)
        {
            var call = await _context.CallLogs.FirstOrDefaultAsync(x => x.CallSid == callSid);
            if (call != null)
            {
                call.Status = status;
                call.EndTime = DateTime.UtcNow;
                if (!string.IsNullOrEmpty(duration))
                    call.Duration = int.Parse(duration);

                await _context.SaveChangesAsync();
            }
        }
    }
}
