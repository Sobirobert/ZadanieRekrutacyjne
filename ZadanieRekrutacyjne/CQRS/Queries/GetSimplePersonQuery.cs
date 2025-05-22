using Application.Dto;
using MediatR;

namespace ZadanieRekrutacyjne.CQRS.Queries;

public class GetSimplePersonQuery(Guid personId) : IRequest<SimplePersonDto>
{
    public Guid PersonId { get; } = personId;
}
