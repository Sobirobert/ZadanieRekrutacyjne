using Application.Dto;
using Application.ServicesInterfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class ServiceSimplePerson(IMapper mapper, IRepository repository) : BaseGenericService(repository), IServiceSimplePerson

{
    private readonly IMapper _mapper = mapper;
    private readonly IRepository _repository = repository;

    public async Task<SimplePersonDto> GetSimplePersonById(Guid id)
    {
        var searchingObj = await GetObjectById<SimplePersonDto>(id);
        if (searchingObj != null)
        {
            var personDto = _mapper.Map<SimplePersonDto>(searchingObj);
            return searchingObj;
        }
        throw new Exception("Wrong id, object with that id doesn't exist");
    }

    public async Task<IEnumerable<SimplePersonDto>> GetAllSimplePersonPesel()
    {
        var allObjects = await GetAllObjects<SimplePersonDto>();
        if (allObjects != null)
        {
            var personDto = _mapper.Map<IEnumerable<SimplePersonDto>>(allObjects);
            return personDto;
        }

        throw new Exception("Empty doesn't exist");
    }

    public async Task AddSimplePersonPesel(CreateSimplePersonDto newObject)
    {
        if (newObject != null)
        {
            var person = _mapper.Map<Simple>(newObject);
            await AddService<Simple>(person);
        }
        throw new Exception("This obj exist");
    }

    public async Task UpdateSimplePerson(SimplePersonDto updateObject)
    {
        var checkObject = await GetObjectById<SimplePersonDto>(updateObject.Id);
        if (checkObject != null)
        {
            var updatedObject = _mapper.Map(updateObject, checkObject);
            await UpdateObject<SimplePersonDto>(updatedObject);
        }
        throw new Exception("This person doesn't exist");
    }

    public async Task RemoveSimplePerson(Guid id)
    {
        var checkObject = await GetObjectById<SimplePersonDto>(id);
        if (checkObject != null)
        {
            await RemoveService<SimplePersonDto>(id);
        }
        throw new Exception("This person doesn't exist");
    }
}
