﻿using AcilKan.Application.Features.Mediator.Commands.SupporterCommands;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.SupporterHandlers
{
    public class DeleteSupporterCommandHandler(IRepository<Supporter> _repository) : IRequestHandler<DeleteSupporterCommand>
    {
        async Task IRequestHandler<DeleteSupporterCommand>.Handle(DeleteSupporterCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
