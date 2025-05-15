using Application.Dto;

namespace Application.ServicesInterfaces;

public interface IServiceSimplePerson : IService
{
    Task<SimplePersonDto> GetSimplePersonById(Guid id);
    Task<IEnumerable<SimplePersonDto>> GetAllSimplePersonPesel();
    Task AddSimplePersonPesel(CreateSimplePersonDto newObject);
    Task UpdateSimplePerson(SimplePersonDto updateObject);
    Task RemoveSimplePerson(Guid id);
}
