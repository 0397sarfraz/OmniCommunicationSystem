using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Domain.Interfaces
{
    public interface ITwilioService
    {
        Task<string> MakeCallAsync(string toNumber);
    }
}
