using MediatR;
using Omni.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Application.Command
{
    public record CreateCallLogCommand(string CallSid, string From, string To) : IRequest<Unit>;

    public class CreateCallLogCommandHandler(ICallService service) : IRequestHandler<CreateCallLogCommand, Unit>
    {
        public async Task<Unit> Handle(CreateCallLogCommand request, CancellationToken cancellationToken)
        {
            await service.CreateCallLog(request.CallSid, request.From, request.To);
            return Unit.Value;
        }
    }

}
