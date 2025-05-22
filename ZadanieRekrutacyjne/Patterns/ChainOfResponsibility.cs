using Domain.Entities;
using ZadanieRekrutacyjne.Patterns.FactoryPattern;

namespace ZadanieRekrutacyjne.Patterns;
public interface IHandle<T>
{
    public Task Handle(T input);
}

public class HandleTwo : IHandle<string>
{
    private readonly IHandle<string> _next;

    public HandleTwo(IHandle<string> next)
    {
        _next = next;
    }

    public async Task Handle(string input)
    {
        Console.WriteLine($"HandleTwo: {input}");
        await _next.Handle(input);
    }

    public class HandleThree : IHandle<string>
    {
        private readonly IHandle<string> _next;

        public async Task Handle(string input)
        {
            Console.WriteLine($"HandleThree: {input}");
            await Task.CompletedTask;
        }
    }
}