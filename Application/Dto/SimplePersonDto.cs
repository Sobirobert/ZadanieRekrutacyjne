using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Dto;

public class SimplePersonDto(Guid Id, string Name, string Surname, string Street, string NumberOfHouse, string ZipCode, string City) 
    : IMap, IRepositoryObject
{
    public Guid Id { get; } = Id;
    public string Name { get; } = Name;
    public string Surname { get; } = Surname;
    public string Street { get; } = Street;
    public string NumberOfHouse { get; } = NumberOfHouse;
    public string ZipCode { get; } = ZipCode;
    public string City { get; } = City;
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Simple, SimplePersonDto>();
    }
}

