using ZadanieRekrutacyjne.Models;

namespace ZadanieRekrutacyjne.Patterns;

public class Builder
{
    private Guid id;
    public PersonalBuilder Add(Guid id)
    {
        this.id = id;
        return this;
    }
    public Person Build()
    {
        var person = new Person.Simple(id, "John", "Doo");
        return person;
    }
}
