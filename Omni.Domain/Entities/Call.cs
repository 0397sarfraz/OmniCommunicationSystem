using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Domain.Entities
{
    // Call.cs
    public class Call
    {
        public int Id { get; set; }
        public string FromNumber { get; set; }= null!;
        public string ToNumber { get; set; }=null!;
        public string CallSid { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string RecordingUrl { get; set; } = null!;
    }
}
