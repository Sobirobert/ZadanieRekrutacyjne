using ZadanieRekrutacyjne.Models;

namespace Domain.Entities;

public record WithPesel(Guid Id, string Name, string Surname, string Pesel, string Street, string NumberOfHouse, string ZipCode, string City)
   : Person(Street, NumberOfHouse, ZipCode, City);
