using Omni.Domain.Entities;
using Omni.Domain.Interfaces;
using Omni.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Omni.Infrastructure.Services
{
    public class IvrService(AppDbContext _context) : IIvrService
    {
        public async Task<IvrMenu> GetByDigit(string digit)
        {
            int d = int.Parse(digit);

            return await _context.IvrMenus
                .FirstOrDefaultAsync(x => x.Digit == d);
        }

        public async Task<IvrMenu> GetRoot()
        {
            return await _context.IvrMenus.FirstOrDefaultAsync(x => x.Digit == null);
        }
    }
}
