using Application.Dto;
using MediatR;

namespace ZadanieRekrutacyjne.CQRS.Commands;

public class CreateNewSimplePersonCommand(CreateSimplePersonDto simplePerson) : IRequest<Unit>
{
}
