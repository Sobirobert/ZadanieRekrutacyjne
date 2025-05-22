namespace ZadanieRekrutacyjne.Patterns;

public interface ICommandHandler<in T>
{
    public Task Handle(T command);
}
public interface IQueryHandler<in TQuery, TResult>
{
    public Task<TResult> Handle(TQuery query);
}
public class CQRS
{

}
