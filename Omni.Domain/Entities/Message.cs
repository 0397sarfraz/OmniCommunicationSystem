using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Domain.Entities
{
    // Message.cs
    public class Message
    {
        public int Id { get; set; }
        public string ToNumber { get; set; } = null!;
        public string Body { get; set; } = null!;
        public string Type { get; set; } = null!;
    }
}
