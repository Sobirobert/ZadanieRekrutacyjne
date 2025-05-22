using Application.Dto;
using Application.ServicesInterfaces;
using AutoMapper;
using MediatR;

namespace ZadanieRekrutacyjne.CQRS.Commands;

public class CreateNewSimplePersonHandler(IServiceSimplePerson serviceSimplePerson, IMapper mapper) : IRequestHandler<CreateNewSimplePersonCommand, Unit>
{
    private readonly IServiceSimplePerson _serviceSimplePerson = serviceSimplePerson;
    private readonly IMapper _mapper = mapper;

    public async Task<Unit> Handle(CreateNewSimplePersonCommand request, CancellationToken cancellationToken)
    {
        var createPersonDto = _mapper.Map<CreateSimplePersonDto>(request);
        await _serviceSimplePerson.AddSimplePerson(createPersonDto);
        return Unit.Value;
    }
}
