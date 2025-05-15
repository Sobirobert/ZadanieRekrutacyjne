using Domain.Common;
using Domain.Interfaces;

namespace Domain.Entities;

public abstract record Person : Adress, IRepositoryObject
{
    protected Person(string Street, string NumberOfHouse, string ZipCode, string Citi) : base(Street, NumberOfHouse, ZipCode, Citi)
    {
    }
}

