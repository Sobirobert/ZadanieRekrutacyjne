using Application.Dto;
using Application.ServicesInterfaces;
using MediatR;

namespace ZadanieRekrutacyjne.CQRS.Queries;

public class GetAllSimplePersonsHandler(IServiceSimplePerson simplePersonService) : IRequestHandler<GetAllSimplePersonsQuery, IEnumerable<SimplePersonDto>>
{
    private readonly IServiceSimplePerson _simplePersonService = simplePersonService;

    public async Task<IEnumerable<SimplePersonDto>> Handle(GetAllSimplePersonsQuery request, CancellationToken cancellationToken)
    {
        var persons = await _simplePersonService.GetAllSimplePerson();
        return persons == null ? null : persons;
    }
}
