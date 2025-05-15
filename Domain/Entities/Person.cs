using Domain.Common;
using Domain.Interfaces;

namespace Domain.Entities;

public abstract record Person : Adress, IRepositoryObject
{
    protected Person( string Name, string Surname, string Street, string NumberOfHouse, string ZipCode, string Citi) : base(Street, NumberOfHouse, ZipCode, Citi)
    {
      
    }

    public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}

