using static ZadanieRekrutacyjne.Patterns.Maybe<T>;
using System;

namespace ZadanieRekrutacyjne.Patterns;

public abstract class Maybe<T>
{
    public abstract Maybe<Tl> Map<Tl>(Func<T, Tl> func);
    public abstract TypedResults MatchWith<TResult>C(Func<TResult> Nonę, Func<T, TResult> Some) pattern);
    public Maybe<Tl> Bind<Tl>(Func<T, Maybe<Tl>> func) => this.MatchWith((
        none: () => new None<T1>(),
        some: (v) => func(v)
        ));
}
public class None<T> : Maybe<T>
{
}
public class Some<T> : Maybe<T>
{
    private readonly T value;
    public Some(T value)
    {
        this.value = value;
    }
}
