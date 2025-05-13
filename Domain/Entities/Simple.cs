using ZadanieRekrutacyjne.Models;

namespace Domain.Entities;

public record Simple(Guid Id, string Name, string Surname, string Street, string NumberOfHouse, string ZipCode, string City)
       : Person(Street, NumberOfHouse, ZipCode, City);
