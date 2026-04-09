using MediatR;
using Omni.Domain.Entities;
using Omni.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Application.Queries
{
    public record GetIVRMenuByDigitQuery(string Digit): IRequest<IvrMenu>;
    

    public class GetIVRMenuByDigitQueryHandler(IIvrService service) : IRequestHandler<GetIVRMenuByDigitQuery, IvrMenu>
    {
        public async Task<IvrMenu> Handle(GetIVRMenuByDigitQuery request, CancellationToken cancellationToken)
        {
            return await service.GetByDigit(request.Digit);
        }
    }
}
