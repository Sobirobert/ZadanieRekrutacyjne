namespace ZadanieRekrutacyjne.Models;

public record Person
{
    public record Simple(Guid Id, string Name, string Surname) : Person;
    public record WithPesel(Guid Id, string Name, string Surname, string Pesel) : Person;
}


