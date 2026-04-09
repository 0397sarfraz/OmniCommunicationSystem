using MediatR;
using Omni.Domain.Entities;
using Omni.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Application.Queries
{
    public record GetIVRMenuQuery : IRequest<IvrMenu>;

    public class GetIVRMenuQueryHandler(IIvrService service) : IRequestHandler<GetIVRMenuQuery, IvrMenu>
    {
        public async Task<IvrMenu> Handle(GetIVRMenuQuery request, CancellationToken cancellationToken)
        {
            return await service.GetRoot();
        }
    }

}
