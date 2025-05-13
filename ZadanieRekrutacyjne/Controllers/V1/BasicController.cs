using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ZadanieRekrutacyjne.Wrappers;

namespace ZadanieRekrutacyjne.Controllers.V1;

[ApiController]
[Route("[controller]")]
public class BasicController
{
    private readonly IService _contextAccessor;
    [HttpGet]
    public IActionResult Get(Guid Id)
    {
        var product = await _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound(id);
        }

        return Ok(new Response<ProductDto>(product));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var allBojects = _contextAccessor.GetAll();
        return Ok(PaginationHelper.CreatePageResponse(products, validPaginationFilter, totalRecords));
    }

    [HttpPost]
    public IActionResult AddNewPerson()
    {
        var product = await _productService.AddNewProduct(newProduct);
        return Created($"api/product/{product.Id}", new Response<ProductDto>(product));
    }

    [HttpPut]
    public IActionResult Update()
    {
        await _productService.UpdateProduct(updateProduct);
        return NoContent();
    }

    [HttpDelete]
    public IActionResult Delete()
    {
        var isAdmin = User.FindFirstValue(ClaimTypes.Role).Contains(UserRoles.Admin);
        if (!isAdmin)
        {
            return BadRequest(new Response(false, "You do not own this product."));
        }
        await _productService.DeleteProduct(id);
        return NoContent();
    }
}

