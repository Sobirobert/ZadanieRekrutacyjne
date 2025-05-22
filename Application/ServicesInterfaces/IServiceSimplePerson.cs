using Application.Dto;

namespace Application.ServicesInterfaces;

public interface IServiceSimplePerson : IService
{
    Task<SimplePersonDto> GetSimplePersonById(Guid id);
    Task<IEnumerable<SimplePersonDto>> GetAllSimplePerson();
    Task AddSimplePerson(CreateSimplePersonDto newObject);
    Task UpdateSimplePerson(SimplePersonDto updateObject);
    Task RemoveSimplePerson(Guid id);
}
