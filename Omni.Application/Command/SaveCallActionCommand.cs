using MediatR;
using Omni.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Application.Command
{
    public record SaveCallActionCommand(string CallSid, string Digit) : IRequest<Unit>;

    public class SaveCallActionCommandHandler(ICallService service) : IRequestHandler<SaveCallActionCommand, Unit>
    {
        public async Task<Unit> Handle(SaveCallActionCommand request, CancellationToken cancellationToken)
        {
            await service.SaveAction(request.CallSid, request.Digit);
            return Unit.Value;
        }
    }
}
