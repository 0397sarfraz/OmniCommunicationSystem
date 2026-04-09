using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Domain.Entities
{
    public class IvrMenu
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int? Digit { get; set; }

        public string ActionType { get; set; } // Transfer, Record, Menu
        public string? ActionValue { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
