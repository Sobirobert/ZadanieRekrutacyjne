using Microsoft.AspNetCore.Mvc;

namespace ZadanieRekrutacyjne.Controllers;

[ApiController]
[Route("[controller]")]
public class BasicController
{
    public IActionResult Get()
    {
        return new OkObjectResult("Hello World");
    }
}
