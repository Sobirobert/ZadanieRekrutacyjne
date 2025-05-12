namespace ZadanieRekrutacyjne.Patterns;

public interface IStrategy 
{
    bool IsValid();
}
public class StrateogyPersonSimple : IStrategy
{
    public bool IsValid()
    {
        return true;
    }
}

public class StrateogyWithPesel : IStrategy
{
    public bool IsValid()
    {
        return true;
    }
}
