using Domain.Common;

namespace ZadanieRekrutacyjne.Models;

public abstract record Person : Adress
{
    protected Person(string Street, string NumberOfHouse, string ZipCode, string Citi) : base(Street, NumberOfHouse, ZipCode, Citi)
    {
    }
}

