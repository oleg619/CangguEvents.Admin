using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CangguEvents.Domain.Models;
using CangguEvents.Domain.Repositories;
using MediatR;

namespace CangguEvents.Api.Events.Queries
{
    public class GetAllUserStatesQuery : IRequest<List<UserState>>
    {
    }

    public class GetAllUserStatesHandler : IRequestHandler<GetAllUserStatesQuery, List<UserState>>
    {
        private readonly IUserStateRepository _repository;

        public GetAllUserStatesHandler(IUserStateRepository repository)
        {
            _repository = repository;
        }

        public Task<List<UserState>> Handle(GetAllUserStatesQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetUserStates(cancellationToken);
        }
    }
}