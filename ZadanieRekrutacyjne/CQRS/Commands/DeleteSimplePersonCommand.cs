using MediatR;

namespace ZadanieRekrutacyjne.CQRS.Commands;

public class DeleteSimplePersonCommand(Guid Id) : IRequest<Unit>
{
    public Guid PersonId { get; } = Id;
}
