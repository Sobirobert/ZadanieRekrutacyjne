using Application.Dto;
using Application.ServicesInterfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ZadanieRekrutacyjne.CQRS.Commands;
using ZadanieRekrutacyjne.CQRS.Queries;
using ZadanieRekrutacyjne.Wrappers;

namespace ZadanieRekrutacyjne.Controllers.V1;
public record PersonRequest(Guid Id, string Name, string Surname, string? Pesel = null);

[ApiVersion("1.0")]
[ApiController]
[Route("api/[controller]")]
public class BasicController(IPersonWithPeselPerson service, IMediator mediator) : ControllerBase
{
    private readonly IPersonWithPeselPerson _service = service;
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    [SwaggerOperation(Summary = "Retrieves person by id")]
    public async Task <IActionResult> Get(Guid id)
    {
        var query = new GetSimplePersonQuery(id);
        var result = await _mediator.Send(query);
        return Ok(new Response<SimplePersonDto>(result));
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Retrieves all person with pesel")]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllSimplePersonsQuery();
        var result = await _mediator.Send(query);
        return Ok(new Response<IEnumerable<SimplePersonDto>>(result));
    }

    [HttpPost]
    public async Task<IActionResult> AddNewPerson(CreateSimplePersonDto newPerson)
    {
        var command = new CreateNewSimplePersonCommand(newPerson);
        var result = await _mediator.Send(command);
        return Created($"api/person/{newPerson.Id}", new Response<CreateSimplePersonDto>(newPerson));
    }

    [HttpPut]
    public async Task<IActionResult> Update(SimplePersonDto updatePerson)
    {

        var command = new UpdateSimplePersonCommand(updatePerson);
        var result = _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteSimplePersonCommand(id);
        var result = _mediator.Send(command);
        return NoContent();
    }
}

