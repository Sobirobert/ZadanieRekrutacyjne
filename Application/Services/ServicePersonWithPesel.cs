using Application.Dto;
using Application.ServicesInterfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class ServicePersonWithPesel(IMapper mapper, IRepository repository) : BaseGenericService(repository), IPersonWithPeselPerson

{
    private readonly IMapper _mapper = mapper;
    private readonly IRepository _repository = repository;
    public async Task<PersonWithPeselDto> GetPersonWithPeselById(Guid id)
    {

        var searchingObj = await GetObjectById<PersonWithPeselDto>(id);
        if (searchingObj != null)
        {
            var personDto = _mapper.Map< PersonWithPeselDto> (searchingObj);
            return searchingObj;
        }
        throw new Exception("Wrong id, object with that id doesn't exist");
    }

    public async Task<IEnumerable<PersonWithPeselDto>> GetAllPersonsWithPesel() 
    {
        var allObjects = await GetAllObjects<PersonWithPeselDto>();
        if (allObjects != null)
        {
            var personDto = _mapper.Map<IEnumerable<PersonWithPeselDto>>(allObjects);
            return personDto;
        }
        
        throw new Exception("Empty doesn't exist");
    }
    public async Task AddPersonWithPesel(CreatePersonWithPeselDto newObject)
    {
        
        if (newObject != null)
        {
            var person = _mapper.Map<WithPesel>(newObject);
            await AddService<WithPesel>(person);
        }
        throw new Exception("This obj exist");
    }

    public async Task UpdatePersonWithPesel(PersonWithPeselDto updateObject)
    {
        var checkObject = await GetObjectById<PersonWithPeselDto>(updateObject.Id);
        if (checkObject != null)
        {
            var updatedObject = _mapper.Map(updateObject, checkObject);
            await UpdateObject<PersonWithPeselDto>(updatedObject);
        }
        throw new Exception("This obj doesn't exist");
    }

    public async Task RemovePersonWithPesel(Guid id)
    {
        var checkObject = await GetObjectById<PersonWithPeselDto>(id);
        if (checkObject != null)
        {
            await RemoveService<PersonWithPeselDto>(id);
        }
        throw new Exception("This obj doesn't exist");
    }
}
