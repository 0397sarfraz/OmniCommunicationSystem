using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Domain.Entities
{
    public class CallAction
    {
        public int Id { get; set; }

        public int CallLogId { get; set; }
        public CallLog CallLog { get; set; }

        public int DigitPressed { get; set; }
        public string ActionType { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
