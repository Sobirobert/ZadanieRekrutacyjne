using Application.Dto;
using Application.ServicesInterfaces;
using MediatR;

namespace ZadanieRekrutacyjne.CQRS.Queries;

public class GetSimplePersonHandler(IServiceSimplePerson simplePersonService) : IRequestHandler<GetSimplePersonQuery, SimplePersonDto>
{
    private readonly IServiceSimplePerson _simplePersonService = simplePersonService;

    public async Task<SimplePersonDto> Handle(GetSimplePersonQuery request, CancellationToken cancellationToken)
    {
        var picture = await _simplePersonService.GetSimplePersonById(request.PersonId);
        return picture == null ? null : picture;
    }
}
