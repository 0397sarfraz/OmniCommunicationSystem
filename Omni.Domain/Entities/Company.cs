using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Domain.Entities
{
    public class Company
    {
        public  int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        // Navigation
        public ICollection<Agent> Agents { get; set; }
        public ICollection<IvrMenu> IvrMenus { get; set; }
        public ICollection<CallLog> CallLogs { get; set; }
    }
}
