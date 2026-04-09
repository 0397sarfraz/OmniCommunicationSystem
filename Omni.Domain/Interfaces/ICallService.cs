using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Domain.Interfaces
{
    public interface ICallService
    {
        Task CreateCallLog(string callSid, string from, string to);
        Task SaveAction(string callSid, string digit);
        Task UpdateRecording(string callSid, string url, string duration);
        Task UpdateStatus(string callSid, string status, string duration);
    }
}
