using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Domain.Entities
{
    public class Agent
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAvailable { get; set; } = true;

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
