using MediatR;
using Omni.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Application.Command
{
    public record UpdateCallStatusCommand(string CallSid, string Status, string Duration): IRequest<Unit>;

    public class UpdateCallStatusCommandHandler(ICallService service) : IRequestHandler<UpdateCallStatusCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateCallStatusCommand request, CancellationToken cancellationToken)
        {
            await service.UpdateStatus(request.CallSid, request.Status, request.Duration);
            return Unit.Value;
        }
    }

}
