using Application.Dto;
using Application.ServicesInterfaces;
using AutoMapper;
using MediatR;

namespace ZadanieRekrutacyjne.CQRS.Commands;

public class UpdateSimplePersonHandler(IServiceSimplePerson serviceSimplePerson, IMapper mapper) : IRequestHandler<UpdateSimplePersonCommand, Unit>
{
    private readonly IServiceSimplePerson _serviceSimplePerson = serviceSimplePerson;
    private readonly IMapper _mapper = mapper;
    public async Task<Unit> Handle(UpdateSimplePersonCommand request, CancellationToken cancellationToken)
    {
        var updateSimplePersonDto = _mapper.Map<SimplePersonDto>(request);
        await _serviceSimplePerson.UpdateSimplePerson(updateSimplePersonDto);
        return Unit.Value;
    }
}
