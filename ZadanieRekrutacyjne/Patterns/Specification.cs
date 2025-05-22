namespace ZadanieRekrutacyjne.Patterns;

public interface ISpecification<T> where T : class
{

    bool IsSatisfiedBy(T input);
}

public abstract class Specification<T> : ISpecification<T> where T : class
{
    public abstract bool IsSatisfiedBy(T input);

    public ISpecification<T> And(ISpecification<T> other)
    {

        return new AndSpecification<T>(this, other);
    }

    public ISpecification<T> Or(ISpecification<T> other)
    {
        return new OrSpecification<T>(this, other);
    }

}
public class AndSpecification<T> : Specification<T> where T : class
{
    private readonly Specification<T> left;
    private readonly Specification<T> right;
    public AndSpecification(Specification<T> left, Specification<T> right)
    {
        this.left = left;
        this.right = right;
    }
    public override bool IsSatisfiedBy(T input)
    {
        return left.IsSatisfiedBy(input) && right.IsSatisfiedBy(input);
    }
}

public class Rule<T> where T : class
{
    public ISpecification<T> _specification;
    public Rule(ISpecification<T> specification)
    {
        _specification = specification;
    }
}

public abstract class Validator<T> where T : class
{
    private List<Rule<T>> rules = new();
    public Validator<T> Add(Rule<T> rule)
    {
        rules.Add(rule);
        return this;
    }

    public T Execute(T input)
    {
        foreach (var rule in rules)
        {
            if (rule._specification.IsSatisfiedBy(input) == false)
            {
                throw new Exception("Validation failed");
            }
            
        }
        return input;
    }
}