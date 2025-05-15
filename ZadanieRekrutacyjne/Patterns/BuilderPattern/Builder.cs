using Domain.Entities;
using ZadanieRekrutacyjne.Models;

namespace ZadanieRekrutacyjne.Patterns.Builder;

public class Builder
{
    private Guid id;
    public PersonalBuilder Add(Guid id)
    {
        this.id = id;
        return this;
    }
    public Models.Person Build()
    {
        var person = new Simple(id, "John", "Doo");
        return person;
    }
}
