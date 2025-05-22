using Application.Dto;
using MediatR;

namespace ZadanieRekrutacyjne.CQRS.Queries;

public class GetAllSimplePersonsQuery() : IRequest<IEnumerable<SimplePersonDto>>
{
}
