using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Domain.Entities
{
    public class CallLog
    {
        public int Id { get; set; }
        public string CallSid { get; set; }

        public string FromNumber { get; set; }
        public string ToNumber { get; set; }

        public string Status { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public int? Duration { get; set; }
        public string? RecordingUrl { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public ICollection<CallAction> CallActions { get; set; }
    }
}
