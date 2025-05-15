using Application.Dto;

namespace Application.ServicesInterfaces;

public interface IPersonWithPeselPerson : IService
{
    Task<PersonWithPeselDto> GetPersonWithPeselById(Guid id);
    Task<IEnumerable<PersonWithPeselDto>> GetAllPersonsWithPesel();
    Task AddPersonWithPesel(CreatePersonWithPeselDto newObject);
    Task UpdatePersonWithPesel(PersonWithPeselDto updateObject);
    Task RemovePersonWithPesel(Guid id);
}