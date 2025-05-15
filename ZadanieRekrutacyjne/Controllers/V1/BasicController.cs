using Application.Dto;
using Application.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ZadanieRekrutacyjne.Wrappers;

namespace ZadanieRekrutacyjne.Controllers.V1;

[ApiVersion("1.0")]
[ApiController]
[Route("api/[controller]")]
public class BasicController(IPersonWithPeselPerson service) : ControllerBase
{
    private readonly IPersonWithPeselPerson _service = service;

    [HttpGet]
    [SwaggerOperation(Summary = "Retrieves person by id")]
    public async Task <IActionResult> Get(Guid id)
    {
        var person = await _service.GetPersonWithPeselById(id);
        if (person == null)
        {
            return NotFound(id);
        }

        return Ok(new Response<PersonWithPeselDto>(person));
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Retrieves all person with pesel")]
    public async Task<IActionResult> GetAll()
    {
        var allPersons = await _service.GetAllPersonsWithPesel();
        if (allPersons == null)
        {
            return BadRequest();
        }
        return Ok(new Response<IEnumerable<PersonWithPeselDto>>(allPersons));
    }

    [HttpPost]
    public async Task<IActionResult> AddNewPerson(CreatePersonWithPeselDto newPerson)
    {
        await _service.AddPersonWithPesel(newPerson);
        return Created($"api/product/{newPerson.Id}", new Response<CreatePersonWithPeselDto>(newPerson));
    }

    [HttpPut]
    public async Task<IActionResult> Update(PersonWithPeselDto updatePerson)
    {
        await _service.UpdatePersonWithPesel(updatePerson);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.RemovePersonWithPesel(id);
        return NoContent();
    }
}

