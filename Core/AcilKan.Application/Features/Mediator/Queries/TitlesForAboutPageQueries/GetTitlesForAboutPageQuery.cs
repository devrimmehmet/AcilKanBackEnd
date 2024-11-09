﻿using AcilKan.Application.Features.Mediator.Results.TitlesForAboutPageResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Queries.TitlesForAboutPageQueries
{
    public class GetTitlesForAboutPageQuery : IRequest<List<GetTitlesForAboutPageQueryResult>>
    {
    }
}
