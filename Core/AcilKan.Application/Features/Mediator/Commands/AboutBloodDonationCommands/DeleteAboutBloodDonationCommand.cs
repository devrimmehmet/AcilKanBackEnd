﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Commands.AboutBloodDonationCommands
{
    public class DeleteAboutBloodDonationCommand(int id) : IRequest
    {
        public int Id { get; set; } = id;
    }
}
