using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CangguEvents.Domain.Models;
using CangguEvents.Domain.Repositories;
using MediatR;

namespace CangguEvents.Api.Events.Queries
{
    public class GetAllEventsQuery : IRequest<List<EventInfo>>
    {
    }

    public class GetWeatherForecastsQueryHandler : IRequestHandler<GetAllEventsQuery, List<EventInfo>>
    {
        private readonly IEventsRepository _eventsRepository;

        public GetWeatherForecastsQueryHandler(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public Task<List<EventInfo>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            return _eventsRepository.GetAllEvents(cancellationToken);
        }
    }
}