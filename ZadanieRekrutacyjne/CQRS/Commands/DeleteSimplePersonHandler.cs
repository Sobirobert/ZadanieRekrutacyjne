using Application.Dto;
using Application.Services;
using Application.ServicesInterfaces;
using AutoMapper;
using MediatR;

namespace ZadanieRekrutacyjne.CQRS.Commands;

public class DeleteSimplePersonHandler(IServiceSimplePerson serviceSimplePerson) : IRequestHandler<DeleteSimplePersonCommand, Unit>
{
    private readonly IServiceSimplePerson _serviceSimplePerson = serviceSimplePerson;

    public async Task<Unit> Handle(DeleteSimplePersonCommand request, CancellationToken cancellationToken)
    {
        await _serviceSimplePerson.RemoveSimplePerson(request.PersonId);
        return Unit.Value;
    }
}
