using MediatR;
using Omni.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Application.Command
{
    public record MakeCallCommand(string toNumber) : IRequest<string>;

    public class MakeCallCommandHandler(ITwilioService service) : IRequestHandler<MakeCallCommand, string>
    {       
        public async Task<string> Handle(MakeCallCommand request, CancellationToken cancellationToken)
        {
          return  await service.MakeCallAsync(request.toNumber);
           
        }
    }

}
