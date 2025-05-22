using Application.Dto;
using MediatR;

namespace ZadanieRekrutacyjne.CQRS.Commands;

public class UpdateSimplePersonCommand(SimplePersonDto simplePerson) : IRequest<Unit>
{
    public SimplePersonDto SimplePerson { get; } = simplePerson;
}

