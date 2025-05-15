using Cosmonaut.Attributes;
using Domain.Interfaces;
using Newtonsoft.Json;

namespace Domain.Entities;

public record WithPesel( Guid Id, string Name, string Surname, string Pesel, string Street, string NumberOfHouse, string ZipCode, string City)
   : Person(Street, NumberOfHouse, ZipCode, City), IRepositoryObject
{
    [CosmosPartitionKey]
    [JsonProperty]
    public Guid Id { get; } = Id;
}
