using Omni.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Domain.Interfaces
{
    public interface IIvrService
    {
        Task<IvrMenu> GetRoot();
        Task<IvrMenu> GetByDigit(string digit);
    }
}
