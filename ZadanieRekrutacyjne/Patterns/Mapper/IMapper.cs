using Domain.Entities;
using System;
using System.Reflection.Metadata.Ecma335;
using ZadanieRekrutacyjne.Controllers.V1;
using ZadanieRekrutacyjne.Models;

namespace ZadanieRekrutacyjne.Patterns.Mapper;

public interface IMapper<in Input, out Output> where Input : class where Output : class
{
    public Output Map(Input input);
}

public class PersonRequestMapper : IMapper<PersonRequest, Person>
{
    public Models.Person Map(PersonRequest input)
    {
        if ()
            return new Person.Simple(input.Id, input.Name, input.Surname);
        else
            return new Person.WithPesel(input.Id, input.Name, input.Surname, input.Pesel);
    }

}