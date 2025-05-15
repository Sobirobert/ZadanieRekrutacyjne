using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Dto;

public class PersonWithPeselDto(Guid Id, string Name, string Surname, string Pesel, string Street, string NumberOfHouse, string ZipCode, string City) 
    : IMap, IRepositoryObject

{
    public Guid Id { get; } = Id;
    public string Name { get; } = Name;
    public string Surname { get; } = Surname;
    public string Pesel { get; } = Pesel;
    public string Street { get; } = Street;
    public string NumberOfHouse { get; } = NumberOfHouse;
    public string ZipCode { get; } = ZipCode;
    public string City { get; } = City;
    Guid IRepositoryObject.Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<WithPesel, PersonWithPeselDto>();
    }
}
