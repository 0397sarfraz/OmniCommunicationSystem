using MediatR;
using Omni.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Application.Command
{
    public record UpdateRecordingCommand(string CallSid, string RecordingUrl, string Duration): IRequest<Unit>;

    public class UpdateRecordingCommandHandler(ICallService service) : IRequestHandler<UpdateRecordingCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateRecordingCommand request, CancellationToken cancellationToken)
        {
            await service.UpdateRecording(request.CallSid, request.RecordingUrl, request.Duration);
            return Unit.Value;
        }
    }
}
